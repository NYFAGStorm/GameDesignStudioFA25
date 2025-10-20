using UnityEngine;

[System.Serializable]
public struct UniqueAttacker
{
    public AttackerType type;
    public Sprite attackerImage;
    public DamageForm damageType;
    public AttackForm attackType;
    public int attackDamage;
    public int health;
    public int maxHealth;
    public int soulReward;
}

[CreateAssetMenu(fileName = "AttackerTypes", menuName = "DemonDefense/AttackerTypes", order = 1)]
public class UniqueAttackers : ScriptableObject
{
    public UniqueAttacker[] attackers;
}
