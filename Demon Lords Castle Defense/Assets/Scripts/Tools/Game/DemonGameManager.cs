using UnityEngine;
using UnityEngine.Events;

public class DemonGameManager : MonoBehaviour
{
    public float demonLordHealth = 30;
    public GameObject gameOverScreen;

    public float danceOffTimer = 0;
    public GameObject danceOffCutOut;

    [HideInInspector]
    public UnityEvent PauseTowerDefense;

    [HideInInspector]
    public UnityEvent ResumeTowerDefense;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        Invoke("StartMusic", 0.5f);
    }

    private void Update()
    {
        if (danceOffTimer > 0f)
        {
            danceOffTimer -= Time.deltaTime;
            if (danceOffTimer <= 0f)
            {
                danceOffTimer = 0f;
                // time up
                Debug.Log("Dance Off Countdown finished. Beginning Dance Off...");
                FindFirstObjectByType<RhythmGameManager>().StartMinigame(Random.Range(10, 21));
                danceOffCutOut.SetActive(false);
            }
        }
    }

    private void StartMusic()
    {
        FindFirstObjectByType<AudioManager>().StartSound("RhythmGameMusic");
    }

    public void DamageDemonLord(int damage)
    {
        demonLordHealth -= damage;

        if (demonLordHealth <= 0)
        {
            gameOverScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void EnemyReachedEnd()
    {
        PauseTowerDefense.Invoke();

        // Ellington: Added Dance off cut out display and timer
        danceOffCutOut.SetActive(true);
        danceOffTimer = 2;
    }

}
