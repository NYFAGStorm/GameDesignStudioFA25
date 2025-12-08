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

    public GameObject[] heroNotes;
    public int totalScore;
    public RhythmGameType gameType;
    public Transform[] heroSpawns;

    //private void Update()
    //{
    //    // can get notes while spawning
    //    note = GameObject.FindGameObjectsWithTag("Note");
    //}

    public void StartMinigame(int noteCount)
    {
        remainingNotes = noteCount;

        NextNote();
    }

    private void NextNote()
    {
        int lane = Random.Range(0, heroSpawns.Length);

        GameObject newNote = Instantiate(heroNotes[Random.Range(0, heroNotes.Length)], heroSpawns[lane].position, Quaternion.identity);
        //newNote.GetComponent<Note>
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
