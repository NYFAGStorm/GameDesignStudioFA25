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
    private List<Vector3> path;
    
    [HideInInspector]
    public UnityEvent UpdateExistingAttackers;
    public GameObject attackerBase;
    public UniqueAttackers types;
    public TileFloorManager tfm;
    public Wavemanager wavemanager;

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
        if (!tfm.validPath)
        {
            Debug.LogWarning("No valid path generated!");
            return null;
        }

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
        newAttacker.InitializeAttacker(path, attackerData, path[0]);

        UpdateExistingAttackers.Invoke();

        return newAttacker;
    }

    public void Die()
    {
        if (wavemanager != null)
        {
            wavemanager.OnAttackerDie();
        }

     
    }
}
