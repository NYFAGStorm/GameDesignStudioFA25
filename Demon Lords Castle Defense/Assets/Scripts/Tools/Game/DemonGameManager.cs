using UnityEngine;
using UnityEngine.Events;

public class DemonGameManager : MonoBehaviour
{
    public float demonLordHealth = 30;
    public GameObject gameOverScreen;

    [HideInInspector]
    public UnityEvent PauseTowerDefense;

    [HideInInspector]
    public UnityEvent ResumeTowerDefense;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        Invoke("StartMusic", 0.5f);
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

        FindFirstObjectByType<RhythmGameManager>().StartMinigame(Random.Range(10, 21));

    }
}
