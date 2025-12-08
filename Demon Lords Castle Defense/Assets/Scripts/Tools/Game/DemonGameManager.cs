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
    }

    public void DamageDemonLord(int damage)
    {
        demonLordHealth -= damage;
    }

    public void EnemyReachedEnd()
    {
        PauseTowerDefense.Invoke();

        FindFirstObjectByType<RhythmGameManager>().StartMinigame(Random.Range(10, 21));

        //demonLordHealth--;

        //if (demonLordHealth == 0)
        //{
        //    gameOverScreen.SetActive(true);

        //    Time.timeScale = 0;
        //}
    }
}
