using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

// Author: Gustavo Rojas Flores
// Manages all types and enums relating to Attackers, as well as creation of Attackers

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
    [HideInInspector]
    public UnityEvent UpdateExistingAttackers;
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

        UpdateExistingAttackers.Invoke();

        return newAttacker;
    }
}
