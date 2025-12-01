using UnityEngine;

public class DemonGameManager : MonoBehaviour
{
    public float demonLordHealth = 10;
    public GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void EnemyReachedEnd()
    {
        demonLordHealth--;

        if (demonLordHealth == 0)
        {
            gameOverScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
