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

    // [need to change to private once debug done]
    public int totalScore;

    private GameObject[] note;

    public RhythmGameType gameType;

    private void Update()
    {
        // can get notes while spawning
        note = GameObject.FindGameObjectsWithTag("Note");
    }

    public int UpdateScore()
    {
        for (int i = 0; i < note.Length; i++)
        {
            totalScore += note[i].gameObject.GetComponent<RhythmicNote>().currentScore;
        }

        Debug.Log(totalScore);
        return totalScore;
    }
}// end of script
