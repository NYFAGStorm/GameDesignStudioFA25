using UnityEngine;

public class RhythmicNote : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this judges the accuracy of input to each note

    public bool isPartiallyOverlapped = false;
    
    // Ranging from Perfect (100%), Great (75%), Good (50%), Poor (25%), Miss (0%)

    void Update()
    {
        // [space] to hit note
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitNote();
        }

        
    }

    private void HitNote()
    {
         Debug.Log ("HIT");
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        //Debug.Log("triggered");
        if (other.name == "Target")  isPartiallyOverlapped = true;
        else isPartiallyOverlapped = false;

        //Debug.Log(isPartiallyOverlapped);
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D other)
    {
        //Debug.Log("left");
        if (other.name == "Target")  isPartiallyOverlapped = false;

        //Debug.Log(isPartiallyOverlapped);
    }
}// end of script
