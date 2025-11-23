using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles showing the onboarding/tutorial

    private bool isSkipped = false;

    public GameObject textbox;
    public GameObject[] dialogueText;
    public GameObject snowBall;
    public GameObject demonLord;
    public Sprite[] snowBallSprites;
    public Sprite[] demonLordSprites;

    private int i = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            
            if (i < (dialogueText.Length - 1))
            {
                NextDialogue();
            }

            if (i >= (dialogueText.Length - 1))
            {
                this.gameObject.SetActive(false);
                Debug.Log("End of Tutorial");
            }
            Debug.Log(i);
        }
    }

    public void NextDialogue()
    {
            dialogueText[i].SetActive(false);
            i++;
            dialogueText[i].SetActive(true);

            if (dialogueText[i].tag == "Snowball")
            {
                SnowballTalk();
                demonLord.SetActive(true);
                snowBall.SetActive(true);
                snowBall.transform.Find("Snowball Name").gameObject.SetActive(true);
                demonLord.transform.Find("Demon Lord Name").gameObject.SetActive(false);
                textbox.GetComponent<Image>().enabled = true;
            }
            if (dialogueText[i].tag == "DemonLord")
            {
                DemonLordTalk();
                demonLord.SetActive(true);
                snowBall.SetActive(true);
                snowBall.transform.Find("Snowball Name").gameObject.SetActive(false);
                demonLord.transform.Find("Demon Lord Name").gameObject.SetActive(true);
                textbox.GetComponent<Image>().enabled = true;
            }
            if (dialogueText[i].tag == "Tooltip")
            {
                textbox.GetComponent<Image>().enabled = false;
                demonLord.SetActive(false);
                snowBall.SetActive(false);
            }        
    }

    private void SnowballTalk()
    {
        snowBall.GetComponent<Image>().color = new Color (1f, 1f, 1f);
        demonLord.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
    }

    private void DemonLordTalk()
    {
        snowBall.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
        demonLord.GetComponent<Image>().color = new Color(1f, 1f, 1f);
    }

    public void SkipTutorial()
    {
        isSkipped = true;
        this.gameObject.SetActive(false);
    }
}// end of class
