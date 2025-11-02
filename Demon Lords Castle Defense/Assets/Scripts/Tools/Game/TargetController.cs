using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the target area for the rhythm notes

    // [need to change to private once done]
    public Image idleTargetImage;
    public Image hitTargetImage;

    void Update()
    {
        // [SPACE] to hit notes
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // change target image to show feedback
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // change target image to default
        }
    }

}// end of script
