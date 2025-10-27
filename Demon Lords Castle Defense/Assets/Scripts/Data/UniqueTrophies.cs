using UnityEngine;

[System.Serializable]
public struct UniqueTrophy
{
    public float effectAmount;
}

[CreateAssetMenu(fileName = "TrophyTypes", menuName = "DemonDefense/TrophyTypes", order = 3)]
public class UniqueTrophies : ScriptableObject
{
    public UniqueTrophy[] trophies;
}
