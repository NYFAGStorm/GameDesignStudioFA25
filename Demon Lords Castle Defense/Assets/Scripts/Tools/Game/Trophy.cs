using UnityEngine;

public class Trophy : Placeable
{
    protected TrophyType type;
    protected float healthBoost;
    protected float damageBoost;
    
    public void InitializeTrophy(UniqueTrophy data)
    {
        type = data.type;
        healthBoost = data.healthAdditive;
        damageBoost = data.attackAdditive;

        GetComponentInChildren<SpriteRenderer>().sprite = data.sprite;
    }

    protected override void OnRelease()
    {
        base.OnRelease();

        if (isPlaced)
        {
            foreach (Goon g in FindObjectsByType<Goon>(FindObjectsSortMode.InstanceID))
            {
                g.SetBoosts(healthBoost, damageBoost);
            }

            FindFirstObjectByType<AudioManager>().StartSound("HeartOfAngel");
        }
    }
    
    protected override void StartDrag()
    {
        base.StartDrag();
    }
}
