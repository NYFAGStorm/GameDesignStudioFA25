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
    public Transform[] transforms; //??

    private int currentWave = 0;
    private int enemiesRemaining = 0;
    public WaveState state;
   

    private void Start()
    {
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
        state = WaveState.Waiting;
    }


}
