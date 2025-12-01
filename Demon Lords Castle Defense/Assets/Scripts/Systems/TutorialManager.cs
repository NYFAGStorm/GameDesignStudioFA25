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
    public GameObject snowBallName;
    public GameObject demonLord;
    public GameObject demonLordName;
    public Sprite[] snowBallSprites;
    public Sprite[] demonLordSprites;

    public GameObject shopOpen;
    public GameObject shopClose;

    private int i = 0;
    private int s = 0;
    private int d = 0;

    private void Start()
    {
        snowBall.GetComponent<Image>().sprite = snowBallSprites[s];

    }
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

        if (i == 12)
        {
            shopClose.SetActive(false);
            shopOpen.SetActive(true);
        }

        if (i == 15)
        {
            shopClose.SetActive(true);
            shopOpen.SetActive(false);
        }

        if (dialogueText[i].tag == "Snowball")
        {
            SnowballTalk();
            demonLord.SetActive(true);
            snowBall.SetActive(true);
            snowBallName.SetActive(true);
            demonLordName.SetActive(false);
            textbox.GetComponent<Image>().enabled = true;
        }
        if (dialogueText[i].tag == "DemonLord")
        {
            DemonLordTalk();
            demonLord.SetActive(true);
            snowBall.SetActive(true);
            snowBallName.SetActive(false);
            demonLordName.SetActive(true);
            textbox.GetComponent<Image>().enabled = true;
        }
        if (dialogueText[i].tag == "Tooltip")
        {
            textbox.GetComponent<Image>().enabled = false;
            demonLord.SetActive(false);
            snowBall.SetActive(false);
            snowBallName.SetActive(false);
            demonLordName.SetActive(false);
        }
    }

    private void SnowballTalk()
    {
        SnowballChangeExpression();

        snowBall.GetComponent<Image>().color = new Color (1f, 1f, 1f);
        demonLord.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
    }

    private void DemonLordTalk()
    {
        DemonLordChangeExpression();

        snowBall.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
        demonLord.GetComponent<Image>().color = new Color(1f, 1f, 1f);
    }

    private void SnowballChangeExpression()
    {
        s++;
        snowBall.GetComponent<Image>().sprite = snowBallSprites[s];
    }

    private void DemonLordChangeExpression()
    {
        d++;
        demonLord.GetComponent<Image>().sprite = demonLordSprites[d];
    }

    public void SkipTutorial()
    {
        isSkipped = true;
        this.gameObject.SetActive(false);
    }
}// end of class
