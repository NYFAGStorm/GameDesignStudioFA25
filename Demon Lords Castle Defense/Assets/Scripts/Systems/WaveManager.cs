using System.Collections;
using UnityEngine;
public enum WaveState
{
    Idle,
    SpawningWave,
    Waiting,
    WaveCompleted,
    AllWavesCompleted
}
public class WaveManager : MonoBehaviour
{
    //LiAi
    //Script to manage for waves

    public UniqueWaves wavesData;
    public AttackerData attackerData;

    private int currentWave = 0;
    private int enemiesRemaining = 0;
    public WaveState state = WaveState.Idle;
   

    private void Start()
    {
        currentWave = 0;
        enemiesRemaining = 0;
        state = WaveState.SpawningWave;
    }

    private void Update()
    {
        switch (state)
        {
            case WaveState.SpawningWave:
                SpawnNextWave();
                break;

            case WaveState.Waiting:
                if (enemiesRemaining == 0)
                {
                    state = WaveState.WaveCompleted;
                }
                break;

            case WaveState.WaveCompleted:
                currentWave++;
                if (currentWave >= wavesData.waves.Length)
                {
                    state = WaveState.AllWavesCompleted;
                }
                else
                {
                    state = WaveState.SpawningWave;
                }
                break;

            case WaveState.AllWavesCompleted:
                break;
        }
    }

    private void SpawnNextWave()
    {
        Wave wave = wavesData.waves[currentWave];

        foreach (EnemyGroup group in wave.group)
        {
            for (int i = 0; i < groups.count; i++)
            {
                Attacker attacker = attackerData.SummonAttacker(group.enemyType);

                if (attacker != null)
                {
                    attacker.waveManager = this;
                    enemiesRemaining++;
                }
            }
        }
    }

    public void OnAttackerDied()
    {
        enemiesRemaining--;
        if (enemiesRemaining < 0) 
            enemiesRemaining = 0;
    }

}
