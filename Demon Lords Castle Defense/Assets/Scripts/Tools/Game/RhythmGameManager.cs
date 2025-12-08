using UnityEngine;

public enum RhythmGameType
{
    Boost,
    DanceOff
}

public class RhythmGameManager : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the total score for each game as well as spawning

    // Contributors: Gustavo Rojas Flores

    // [need to change to private once debug done]
    private int remainingNotes;
    private int totalScore;
    private DemonGameManager dgm;
    private bool gameActive = false;

    public GameObject[] heroNotes;
    public Transform[] heroSpawns;
    public Transform[] misses;
    public RhythmGameType gameType;
    public GameObject danceOffScreen;

    //private void Update()
    //{
    //    // can get notes while spawning
    //    note = GameObject.FindGameObjectsWithTag("Note");
    //}

    private void Awake()
    {
        danceOffScreen.SetActive(false);

        dgm = FindFirstObjectByType<DemonGameManager>();
    }

    [ContextMenu("Dance Off")]
    private void DEBUGStart()
    {
        StartMinigame(10);
    }

    public void StartMinigame(int noteCount)
    {
        if (gameActive) return;

        gameActive = true;
        remainingNotes = noteCount;

        danceOffScreen.SetActive(true);

        NextNote();
    }

    private void StopMinigame()
    {
        if (!gameActive) return;

        gameActive = false;
        danceOffScreen.SetActive(false);

        dgm.ResumeTowerDefense.Invoke();
    }

    private void NextNote()
    {
        if (remainingNotes <= 0)
        {
            CancelInvoke("NextNote");

            Invoke("StopMinigame", 4);
        }
        remainingNotes--;

        int lane = Random.Range(0, heroSpawns.Length);

        GameObject newNote = Instantiate(heroNotes[Random.Range(0, heroNotes.Length)], heroSpawns[lane].position, Quaternion.identity, danceOffScreen.transform);
        newNote.GetComponent<HeroNote>().InitializeNote(lane, 200, 10, heroSpawns[lane].GetComponent<RectTransform>(), misses[lane].GetComponent<RectTransform>());

        Invoke("NextNote", 0.5f);
    }

    public void SuccessfulHit(int score)
    {
        totalScore += score;
    }

    public void Miss()
    {
        dgm.DamageDemonLord(1);
    }

    public int UpdateScore()
    {
        //for (int i = 0; i < note.Length; i++)
        //{
        //    totalScore += note[i].gameObject.GetComponent<RhythmicNote>().currentScore;
        //}

        Debug.Log(totalScore);
        return totalScore;
    }
}// end of script
