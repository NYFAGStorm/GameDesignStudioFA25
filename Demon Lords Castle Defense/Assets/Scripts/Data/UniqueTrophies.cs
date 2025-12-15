using UnityEngine;

[System.Serializable]
public struct UniqueTrophy
{
    public TrophyType type;
    public Sprite sprite;
    public float healthAdditive;
    public float attackAdditive;
}

[CreateAssetMenu(fileName = "TrophyTypes", menuName = "DemonDefense/TrophyTypes", order = 3)]
public class UniqueTrophies : ScriptableObject
{
    public UniqueTrophy[] trophies;
}
