using UnityEngine;

[System.Serializable]
public struct UniqueAttacker
{
    public AttackerType type;
    public Sprite attackerImage;
    public DamageForm damageType;
    public AttackForm attackType;
    public int attackDamage;
    public int maxHealth;
    public int soulReward;
    public float travelSpeed;
    public OnBeat attackRate;
}

[CreateAssetMenu(fileName = "AttackerTypes", menuName = "DemonDefense/AttackerTypes", order = 2)]
public class UniqueAttackers : ScriptableObject
{
    public UniqueAttacker[] attackers;
}
