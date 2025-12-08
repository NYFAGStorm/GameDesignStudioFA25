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
    }

    [ContextMenu("Dance Off")]
    private void DEBUGStart()
    {
        StartMinigame(10);
    }

    public void StartMinigame(int noteCount)
    {
        danceOffScreen.SetActive(true);

        remainingNotes = noteCount;

        NextNote();
    }

    private void StopMinigame()
    {
        danceOffScreen.SetActive(false);

        FindFirstObjectByType<DemonGameManager>().ResumeTowerDefense.Invoke();
    }

    private void NextNote()
    {
        if (remainingNotes <= 0)
        {
            CancelInvoke("NextNote");
            Debug.Log("ASD");

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
