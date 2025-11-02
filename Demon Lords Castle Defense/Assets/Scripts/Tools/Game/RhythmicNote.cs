using UnityEngine;

public class RhythmicNote : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this judges the accuracy of input to each note

    // [need to change to private once done]
    public bool canBePressed = false;
    public bool obtained = false;
    
    public int collisionCounter = 0;
    public bool isGood = false;
    public bool isPerfect = false;

    public int goodScore = 50;
    public int perfectScore = 100;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE");

            if (canBePressed)
            {
                RhythmGameManager.instance.NoteHit();
                obtained = true;
                gameObject.SetActive(false);
            }

            if (!canBePressed)
            {
                RhythmGameManager.instance.NoteMissed();
                obtained = true;
                gameObject.SetActive(false);
            }
            
        }
    }
    // Ranging from Perfect (75%), Great (50%), Good (25%), Miss (0%)
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.tag == "Target")
        {
            collisionCounter++;

            if (collisionCounter > 0) canBePressed = true;
            if (collisionCounter == 1) isGood = true;
            if (collisionCounter == 2) isPerfect = true;
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D other)
    {
        if (other.tag == "Target")
        {
            collisionCounter--;

            if (collisionCounter < 1) canBePressed = false;
            if (collisionCounter == 1) isPerfect = false;
            if (collisionCounter == 0) isGood = false;
        }
    }
}// end of script
