using System.Collections;
using System.Collections.Generic;
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
    // LiAi
    // Script to manage for waves

    private int currentWave = 0;
    private int enemiesRemaining = 0;
    private bool spawning = false;
    private int currentEnemyIndex = 0;
    private List<AttackerType> bakedWave = new List<AttackerType>();
    private TileFloorManager tfm;
    private AttackerData attackerData;
    private DayNightManager dayNightManager; // Ellington: Added DayNightManager for function call

    [HideInInspector]
    public WaveState state = WaveState.Idle;
    public UniqueWaves wavesData;
    public GameObject invalidPathWarning;

    private void Awake()
    {
        tfm = FindFirstObjectByType<TileFloorManager>();
        attackerData = FindFirstObjectByType<AttackerData>();
        dayNightManager = FindFirstObjectByType<DayNightManager>();

        HideWarning();
    }

    public void BeginWave()
    {
        if (spawning) return;

        if (!tfm.validPath)
        {
            invalidPathWarning.SetActive(true);

            CancelInvoke("HideWarning");
            Invoke("HideWarning", 3);

            return;
        }

        // Ellington: Added a function call to start the day
        dayNightManager.SwapToDay();

        spawning = true;
        enemiesRemaining = 0;
        state = WaveState.SpawningWave;

        SpawnNextWave();
        HideWarning();
    }

    private void HideWarning()
    {
        invalidPathWarning.SetActive(false);
    }

    private void Update()
    {
        switch (state)
        {
            case WaveState.SpawningWave:
                //SpawnNextWave();
                break;

            //case WaveState.Waiting:
            //    if (enemiesRemaining == 0)
            //    {
            //        state = WaveState.WaveCompleted;
            //    }
            //    break;

            //case WaveState.WaveCompleted:
            //    currentWave++;
            //    if (currentWave >= wavesData.waves.Length)
            //    {
            //        state = WaveState.AllWavesCompleted;
            //    }
            //    else
            //    {
            //        state = WaveState.SpawningWave;
            //    }
            //    break;

            case WaveState.AllWavesCompleted:
                break;
        }
    }

    private void TimedEnemySpawn()
    {
        Attacker attacker = attackerData.SummonAttacker(bakedWave[currentEnemyIndex]);

        if (attacker != null)
        {
            attacker.waveManager = this;
            enemiesRemaining++;
        }

        currentEnemyIndex++;
    }

    private void SpawnNextWave()
    {
        Wave wave = wavesData.waves[currentWave];

        currentEnemyIndex = 0;
        bakedWave.Clear();

        for (int g = 0; g < wave.groups.Length; g++)
        {
            for (int enemy = 0; enemy < wave.groups[g].count; enemy++)
            {
                bakedWave.Add(wave.groups[g].enemyType);

                Invoke("TimedEnemySpawn", (enemy + g) * 60 / Rhythm.beatsPerMinute);
            }
        }

        state = WaveState.Waiting;
    }

    public void OnAttackerRemoved()
    {
        enemiesRemaining--;

        if (enemiesRemaining == 0)
        {
            state = WaveState.WaveCompleted;

            spawning = false;
            currentWave++;

            dayNightManager.SwapToNight();
        }
    }
}
