using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UniqueGoon
{
    public GoonType type;
    public int damage;
    public AttackForm attackType;
    public float attackRate;
    public Sprite goonImage;
    public float attackRange;
}

[CreateAssetMenu(fileName = "GoonTypes", menuName = "DemonDefense/GoonTypes", order = 3)]
public class UniqueGoons : ScriptableObject
{
    public UniqueGoon[] goons;
}
