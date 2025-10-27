using UnityEngine;
using System.Collections.Generic;

// Author: Gustavo Rojas Flores
// Manages all types and enums relating to Attackers

public enum AttackerType
{
    Priest,
    Archer,
    Assassin,
    Sniper,
    Knight,
    Hunter
}

public enum AttackForm
{
    Melee,
    Ranged
}

public class AttackerData : MonoBehaviour
{
    public GameObject attackerBase;
    public UniqueAttackers types;
    private List<Vector3> path;

    public void UpdatePath(List<Vector3> newPath)
    {
        path = newPath;
    }

    public void DEBUGAttacker()
    {
        SummonAttacker(AttackerType.Priest);
    }

    public Attacker SummonAttacker(AttackerType type)
    {
        UniqueAttacker attackerData = new UniqueAttacker();

        foreach (UniqueAttacker ua in types.attackers)
        {
            if (ua.type == type)
            {
                attackerData = ua;
                break;
            }
        }

        Attacker newAttacker = Instantiate(attackerBase, GameObject.Find("Attackers").transform).GetComponent<Attacker>();
        newAttacker.InitializeAttacker(path, attackerData, Vector3.zero);
        return newAttacker;
    }
}
