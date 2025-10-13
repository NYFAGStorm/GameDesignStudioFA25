using UnityEditor.Experimental.GraphView;
using UnityEngine;

// Author: Gustavo Rojas Flores
// Manages relationships between different damage types

public enum DamageForm
{
    Dark,
    Light,
    Fire,
    Water,
    Air,
    Neutral
}

public struct damageRelation
{
    public DamageForm attacker;
    public DamageForm defender;
    public float damageMult;
}

public static class DamageType
{
    private static float damageDifference = 0.15f;

    public static damageRelation[] damageRelations =
    {
        new damageRelation()
        {
            attacker = DamageForm.Dark,
            defender = DamageForm.Light,
            damageMult = 1 + damageDifference
        },

        new damageRelation()
        {
            attacker = DamageForm.Light,
            defender = DamageForm.Dark,
            damageMult = 1 + damageDifference
        },

        new damageRelation()
        {
            attacker = DamageForm.Dark,
            defender = DamageForm.Dark,
            damageMult = 1 - damageDifference
        },

        new damageRelation()
        {
            attacker = DamageForm.Light,
            defender = DamageForm.Light,
            damageMult = 1 - damageDifference
        },

        new damageRelation()
        {
            attacker = DamageForm.Water,
            defender = DamageForm.Fire,
            damageMult = 1 + damageDifference
        },

        new damageRelation()
        {
            attacker = DamageForm.Fire,
            defender = DamageForm.Water,
            damageMult = 1 - damageDifference
        },

        new damageRelation()
        {
            attacker = DamageForm.Fire,
            defender = DamageForm.Air,
            damageMult = 1 - damageDifference
        },

        new damageRelation()
        {
            attacker = DamageForm.Air,
            defender = DamageForm.Fire,
            damageMult = 1 + damageDifference
        }
    };

    public static float DamageMult(DamageForm attacker, DamageForm defender)
    {
        foreach (damageRelation dr in damageRelations)
        {
            if (dr.attacker == attacker && dr.defender == defender) return dr.damageMult;
        }

        return 1;
    }
}
