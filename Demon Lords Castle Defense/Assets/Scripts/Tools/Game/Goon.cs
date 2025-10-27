using System.Collections.Generic;
using UnityEngine;

public class Goon : Placeable
{
    // Author: Gustavo Rojas Flores
    // Manages a goon that can attack heroes and be upgraded

    private GoonType type;
    private int damage;
    private AttackForm attackType;
    private OnBeat attackRate;
    private List<Attacker> activeAttackers;
    private Attacker target;
    private float maxHealth = 1;
    private float health = 1;
    private float attackRange = 1;
    private int state = 0;
    private PopupBlueprint statDisplayBP;
    private Popup statDisplay = null;

    public SpriteRenderer image;

    public void InitializeGoon(UniqueGoon data)
    {
        maxHealth = data.maxHealth;
        health = data.maxHealth;
        type = data.type;
        damage = data.damage;
        attackType = data.attackType;
        attackRate = data.attackRate;
        attackRange = data.attackRange;
        image.sprite = data.goonImage;

        statDisplayBP = new PopupBlueprint()
        {
            target = transform,
            size = new Vector2(300, 300),
            header = "Goon Stats",
            labels = new PopupLabel[]
            {
                new PopupLabel()
                {
                    text = "Health: " + health,
                    textScale = 50,
                    identifier = "health",
                    size = new Vector2(250, 30),
                    position = new Vector2(0, 50)
                },
                new PopupLabel()
                {
                    text = "Damage: " + damage,
                    textScale = 50,
                    identifier = "damage",
                    size = new Vector2(250, 30),
                    position = new Vector2(0, -50)
                }
            }
        };

        FindFirstObjectByType<GoonData>().ExistingGoonsUpdated.AddListener(UpdateGoons);
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        if (statDisplay)
        {
            statDisplay.Delete();
        }
        else statDisplay = PopupBuilder.CreatePopup(statDisplayBP);
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        if (isPlaced) state = 1;
    }

    protected override void StartDrag()
    {
        base.StartDrag();
        state = 0;
    }

    protected override void Update()
    {
        base.Update();

        if (!isBeingDragged || state == 0) return;

        if (state == 1)
        {
            Attacker closestAttacker = null;
            float closestAttackerDistance = attackRange;

            foreach (Attacker attacker in activeAttackers)
            {
                float dist = Vector3.Distance(transform.position, attacker.transform.position);
                if (dist < attackRange && dist < closestAttackerDistance)
                {
                    closestAttackerDistance = dist;
                    closestAttacker = attacker;
                }
            }

            target = closestAttacker;
            
            if (target)
            {
                state = 2;
                Rhythm.beats[0].AddListener(SingleAttack);
            }
        }
        else state = 1;
    }

    private void SingleAttack()
    {
        Debug.Log("damaged hero for " + damage);
        target.DealDamage(damage);
    }

    private void UpdateGoons()
    {
        activeAttackers = new List<Attacker>(FindObjectsByType<Attacker>(FindObjectsSortMode.InstanceID));
        if (target)
        {
            Rhythm.beats[0].RemoveListener(SingleAttack);
        }
    }

    public void DealDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);
        
        if (health == 0)
        {
            container.RemoveItem(false);
            Destroy(gameObject);
        }
    }

    // Written rules (Esther)
    // speed = 0, Goon is stationary in assigned Slot
    // [Attribute]
    //  if damage type is strong against said Goon, takes +15% more damage.
    //  if damage type is weak against said Goon, takes -15% less damage.

    // [ATTACK- MELEE]
    // attack range = 1/6 of the Tile size, recangular shape
    //      (6 Goons should cover 1 Tile)
    // 1 Goon attack 2 Hero at a time
    // When a hero enters attack range:
    //      if is damaging 2 Heroes, no change
    //      if is damaging 1 Hero, fight the new Hero as well
    //      if is damaging 0 Hero, fight
    // When defeating 1 or 2 hero it's fighting:
    //      if any Hero within attack range, fight the one(s) closest to leaving said range

    // [ATTACK- RANGE]
    // attack range = 1 Tile
    // 1 Goon attack 1 Hero at a time
    // When a hero enters attack range:
    //      if is damaging 1 Hero, no change
    //      if it damaging 0 Hero, fight
    // When defeating 1 Hero
    //      if any Hero within attack range, pick the one closest to leaving said range

    // [General]
    // if removed from slot:
    //      stop attacking
    //      HP remains the same as before removal

    // [UPGRADE]
    // for details of upgrades pls refer to the Characters & Tiles sheet, tab [Goons Upgrade]
    // upgrade cost formula:
    //  lv 2 = base cost * 1.45 (round up)
    //  lv 3-11 = previous cost * 1.3 (round up)
}
