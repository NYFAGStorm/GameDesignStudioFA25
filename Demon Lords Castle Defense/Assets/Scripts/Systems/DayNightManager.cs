using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    // Author: Ellington
    // Handles the swapping of the Day and Night cycles, as well as enabling and disabling associated features

    public bool isNight = true;
    public int currentNight = 1;
    public int currentDay = 1;
    public int finalDay = 5;
    public bool isFinalDay = false;

    /// NTOE: Invalidated
    // public int TotalRounds = 10;
    // public int currentRound;
    // public bool bossRound = false;

    /// NOTE: For testing purposes
    // public float roundTimerDuration = 60f;
    // public float roundTimer;

    public TileFloorManager tileFloorManager;
    public WaveManager waveManager;
    /// NOTE: Might need to disable this, so keep a reference here just in case
    // public GameObject sendEnemyButton;

    void Start()
    {

    }

    void Update()
    {
        if (isNight! && waveManager.state == WaveState.AllWavesCompleted)
        {
            SwapToNight();
        }

        // Timer for testing purposes
        /**
        if (roundTimer > 0f)
        {
            roundTimer -= Time.deltaTime;
            if (roundTimer <= 0f)
            {
                roundTimer = 0f;
                // time up
                Debug.Log("Round timer finished. Ending round...");
                RoundEnd();
            }
        }
        **/
    }

    /// NOTE: Below script has been invalidated
    // Begins the next round
    // Disables the Start Next Round button if it is the boss round
    /**
    public void RoundStart()
    {
        if (currentRound == 0)
        {
            Debug.Log("Day just began, starting round 1!");
            currentRound = 1;
        }
        else if (currentRound < TotalRounds)
        {
            currentRound++;
            if (currentRound == TotalRounds)
            {
                Debug.Log("Boss Round!");
                bossRound = true;
                // ToDo: disable the Start Next Round button
            }
            Debug.Log("New round started!");
        }
        // For testing purposes
        //roundTimer = roundTimerDuration;
    }
    **/

    /// NOTE: Below script has been invalidated
    // Moves the current round count up by 1
    // If the current round is the boss round when this is called, change day to night
    /**
    public void RoundEnd()
    {
        if (!bossRound)
        {
            Debug.Log("Not boss round, starting next round...");
            RoundStart();
        }
        else
        {
            Debug.Log("Was boss round, checking current day...");
            if (isFinalDay == false)
            {
                Debug.Log("Not final day, swaping to night...");
                bossRound = false;
                SwapToNight();
            }
            else
            {
                Debug.Log("Was final day, game over. Player Wins!");
                // ToDo: Start Game Win Sequence
            }
        }
    }
    **/

    // Changes to Day and begins the rounds
    // Changes UI view to Day
    // Disables Tile Movement
    public void SwapToDay()
    {
        isNight = false;
        currentDay++;

        Debug.Log("Day has begun! Locking the floor...");
        tileFloorManager.LockFloor(true);
        // RoundStart();

        if (currentDay == finalDay)
        {
            isFinalDay = true;
            Debug.Log("Final Day!");
        }
    }

    // Changes to Night and clears the current round count
    // Changes UI view to Night
    // Enables Tile Movement
    public void SwapToNight()
    {
        // currentRound = 0;
        isNight = true;
        currentNight++;

        tileFloorManager.LockFloor(false);
        Debug.Log("Night has begun!");
    }
}
