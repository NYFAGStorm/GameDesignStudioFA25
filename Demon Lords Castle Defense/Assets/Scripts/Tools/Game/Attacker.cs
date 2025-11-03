using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Controls an individual attacker

    // Written rules (Esther)
    // [MOVEMENT]
    // speed: 4 sec per Tile
    // HP = 0, death ani, no more attack and movement, give Soul to player

    //[ATTRIBUTE]
    //  if damage type is strong against said Goon, takes +15% more damage.
    //  if damage type is weak against said Goon, takes -15% less damage.

    // [ATTACK - MELEE]
    // 1 hero attack 1 goon at a time
    // if attacked:
    //      if attacked by 1 Goon, fight
    //      if attacked by >1 Goon, fight *closest* Goon
    //      Hero is not allowed to move forward until defeated said Goon, or Goon is removed from Slot
    // when defeated a Goon:
    //      if isn't being attacked, keep move forward
    //      if is being attacked, run [if attacked]

    // [ATTACK - RANGE]
    //   // 1 hero attack 1 goon at a time
    // if attacked:
    //      if attacked by 1 Goon, fight
    //      if attacked by >1 Goon, fight *furthest* Goon
    //      Hero is allowed to move forward before defeated said Goon, movement happens between attacks
    // when defeated a Goon:
    //      if isn't being attacked, keep move forward
    //      if is being attacked, run [if attacked]

    private List<Vector3> path;
    private Vector3 pointA;
    private Vector3 pointB;
    private int currentPathPos = 0;
    private float pointLerp = 0;
    private float speed = 5;
    private float attackDamage = 1;
    private float health = 1;
    private float maxHealth = 1;
    private int soulReward = 1;
    private bool isMoving = false;
    private List<Goon> activeGoons;
    private Goon target = null;
    private float attackRange = 1;
    private AttackerData attackerData;
    private OnBeat attackOnBeat;
    private int state;

    public SpriteRenderer appearance;

    public void InitializeAttacker(List<Vector3> inPath, UniqueAttacker data, Vector3 start)
    {
        transform.localPosition = start;
        path = inPath;

        attackDamage = data.attackDamage;
        health = data.maxHealth;
        maxHealth = data.maxHealth;
        soulReward = data.soulReward;
        speed = data.travelSpeed;
        appearance.sprite = data.attackerImage;
        attackRange = data.attackRange * 2;
        attackOnBeat = data.attackRate;

        attackerData = FindFirstObjectByType<AttackerData>();

        FindFirstObjectByType<GoonData>().ExistingGoonsUpdated.AddListener(UpdateGoons);

        UpdateGoons();

        NextPathPoint();
        isMoving = true;
        state = 1;
    }

    private void UpdateGoons()
    {
        activeGoons = new List<Goon>(FindObjectsByType<Goon>(FindObjectsSortMode.InstanceID));
        if (!target)
        {
            Rhythm.beats[(int)attackOnBeat].RemoveListener(SingleAttack);
        }
    }

    public float PathProgress()
    {
        return currentPathPos + pointLerp;
    }

    private void NextPathPoint()
    {
        currentPathPos++;

        if (currentPathPos == path.Count - 1)
        {
            FindFirstObjectByType<DemonGameManager>().EnemyReachedEnd();
            isMoving = false;

            Destroy(gameObject);
            attackerData.UpdateExistingAttackers.Invoke();

            return;
        }
        
        pointA = path[currentPathPos - 1];
        pointB = path[currentPathPos];
        pointLerp = 0;
    }

    // Returns whether the enemy is still alive after taking the damage
    public bool DealDamage(float damage)
    {
        health = Mathf.Max(0, health - damage);

        Debug.Log("hero health: " + health);
        if (health == 0)
        {
            CurrencyManager.AwardSouls(soulReward);

            Destroy(gameObject);

            attackerData.UpdateExistingAttackers.Invoke();
        }

        return health > 0;
    }

    private void SingleAttack()
    {
        Debug.Log("Damaged goon for " + attackDamage + " damage");
        if (!target.DealDamage(attackDamage))
        {
            Rhythm.beats[0].RemoveListener(SingleAttack);
            target = null;
            state = 1;
            isMoving = true;
        }
    }

    private void Update()
    {
        if (state == 1 && activeGoons.Count > 0)
        {
            Goon closestGoon = null;
            float closestGoonDistance = attackRange;

            List<Goon> bakedActiveGoons = new List<Goon>(activeGoons);

            foreach (Goon goon in bakedActiveGoons)
            {
                if (!goon)
                {
                    activeGoons.Remove(goon);
                    continue;
                }

                float dist = Vector3.Distance(transform.position, goon.transform.position);
                if (dist < attackRange && dist < closestGoonDistance)
                {
                    closestGoonDistance = dist;
                    closestGoon = goon;
                }
            }

            target = closestGoon;

            if (target)
            {
                isMoving = false;
                state = 2;
                Rhythm.beats[(int)attackOnBeat].AddListener(SingleAttack);
            }
        }

        if (!isMoving || state != 1) return;

        pointLerp += (Time.deltaTime * speed) / 5;
        transform.localPosition = Vector3.Lerp(pointA, pointB, pointLerp);

        if (pointLerp > 1)
        {
            NextPathPoint();
        }
    }
}