using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles showing the onboarding/tutorial

    private bool isSkipped = false;

    public GameObject[] snowBallText;
    public Sprite[] snowBallSprites;
    public GameObject[] demonLordText;
    public Sprite[] demonLordSprites;

    public GameObject[] toolTipText;

    void Update()
    {
        
    }

    public void SkipTutorial()
    {
        isSkipped = true;
        this.gameObject.SetActive(false);
    }
}// end of class
