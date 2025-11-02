using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles player feedback

    // [need to change to private once debug done]
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
