using UnityEngine;

[System.Serializable]

//LiAi
//Groups up each wave
public struct EnemyGroup
{
    public AttackerType enemyType;
    public int count;
}

[System.Serializable]
public struct Wave
{
    public EnemyGroup[] groups;

    public float timeRange;
    public OnBeat spawnRate;
}

[CreateAssetMenu(fileName = "Waves", menuName = "DemonDefense/Waves", order = 3)]
public class UniqueWaves : ScriptableObject
{
    public Wave[] waves;
}
