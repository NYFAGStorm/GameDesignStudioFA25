using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the detection of each note as well as spawning

    public static RhythmGameManager instance;

    // [need to change to private once done]
    public int totalScore;
    public int hitGoodScore = 50;
    public int hitPerfectScore = 100;

    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        
    }

    public void NoteHit()
    {
        Debug.Log("hit");
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
    }
}// end of script
