using UnityEngine;

public class RhythmicNote : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this judges the accuracy of input to each note

    // [need to change to private once debug done]
    public bool canBePressed = false;
    public bool obtained = false;
    
    public int collisionCounter = 0;
    public bool isGood = false;
    public bool isPerfect = false;

    public GameObject RhythmGameManager;
    public int currentScore;
    public int goodScore = 1;
    public int perfectScore = 100;

    private void Start()
    {
        RhythmGameManager = GameObject.Find("RhythmGameManager");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE");

            if (canBePressed && !obtained)
            {
                obtained = true;

                // gives a score based on accuracy
                if (collisionCounter == 0) currentScore += 0;
                if (collisionCounter == 1) currentScore += goodScore;
                if (collisionCounter == 2) currentScore += perfectScore;

                // update score to game manager
                RhythmGameManager.GetComponent<RhythmGameManager>().UpdateScore();

                // destroy so game manager doesnt re-add score
                Destroy(gameObject);
            }

            if (!canBePressed)
            {
                Debug.Log("MISS");
            }
            
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.tag == "Target")
        {
            collisionCounter++;
            if (collisionCounter > 0) canBePressed = true;

            // mainly for debugging
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

            // mainly for debugging
            if (collisionCounter == 1) isPerfect = false;
            if (collisionCounter == 0) isGood = false;
        }
    }
}// end of script
