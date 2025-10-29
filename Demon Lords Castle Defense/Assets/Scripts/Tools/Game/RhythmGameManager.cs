using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the detection of each note as well as spawning

    public static RhythmGameManager instance;

    void Start()
    {
        instance = this;
    }

    void Update()
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
