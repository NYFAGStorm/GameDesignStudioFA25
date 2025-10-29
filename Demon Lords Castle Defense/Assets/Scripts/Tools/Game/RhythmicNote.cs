using UnityEngine;

public class RhythmicNote : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this judges the accuracy of input to each note

    public bool canBePressed = false;
    public bool obtained = false;

    // Ranging from Perfect (75%), Great (50%), Good (25%), Miss (0%)

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

    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        //Debug.Log("triggered");
        if (other.tag == "Target") canBePressed = true;
        else canBePressed = false;

        //Debug.Log(canBePressed);
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D other)
    {
        //Debug.Log("left");
        if (other.tag == "Target" && !obtained)
        {
            canBePressed = false;
            RhythmGameManager.instance.NoteMissed();
        }
        //Debug.Log(canBePressed);
    }
}// end of script
