using TMPro;
using UnityEngine;

public enum RhythmGameType
{
    Boost,
    DanceOff
}

public class RhythmGameManager : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the total score for each game as well as spawning

    // Contributors: Gustavo Rojas Flores

    // [need to change to private once debug done]
    private int remainingNotes;
    private int totalScore;
    private DemonGameManager dgm;
    private bool gameActive = false;
    private Animator[] pentagrams = new Animator[4];
    private float maxHealth = 0;
    private KeyCode[] keyMap = { 
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.F
    };

    public GameObject[] heroNotes;
    public Transform[] lanes;
    public RhythmGameType gameType;
    public GameObject danceOffScreen;
    public Transform healthBar;

    //private void Update()
    //{
    //    // can get notes while spawning
    //    note = GameObject.FindGameObjectsWithTag("Note");
    //}

    private void Awake()
    {
        danceOffScreen.SetActive(false);

        dgm = FindFirstObjectByType<DemonGameManager>();

        maxHealth = dgm.demonLordHealth;
        
        int l = 0;
        foreach (Transform lane in lanes)
        {
            pentagrams[l] = lane.Find("Target").GetComponent<Animator>();

            lane.Find("Key").GetComponent<TMP_Text>().text = keyMap[l].ToString();
            l++;
        }
    }

    private void Update()
    {
        int p = 0;

        foreach (Animator pentagram in pentagrams)
        {
            if (Input.GetKeyDown(keyMap[p]))
            {
                pentagram.SetTrigger("Press");
            }

            p++;
        }
    }

    [ContextMenu("Dance Off")]
    private void DEBUGStart()
    {
        StartMinigame(10);
    }

    public void StartMinigame(int noteCount)
    {
        if (gameActive) return;

        gameActive = true;
        remainingNotes = noteCount;

        danceOffScreen.SetActive(true);

        NextNote();
    }

    private void StopMinigame()
    {
        if (!gameActive) return;

        gameActive = false;
        danceOffScreen.SetActive(false);

        dgm.ResumeTowerDefense.Invoke();
    }

    private void NextNote()
    {
        if (remainingNotes <= 0)
        {
            CancelInvoke("NextNote");

            Invoke("StopMinigame", 3);

            return;
        }
        remainingNotes--;

        int lane = Random.Range(0, lanes.Length);

        GameObject newNote = Instantiate(heroNotes[Random.Range(0, heroNotes.Length)], lanes[lane].Find("Spawn").position, Quaternion.identity, danceOffScreen.transform);
        newNote.GetComponent<HeroNote>().InitializeNote(lane, 250, 40, lanes[lane].Find("Target").GetComponent<Transform>(), lanes[lane].Find("Miss").GetComponent<Transform>());

        Invoke("NextNote", 0.5f);
    }

    public void SuccessfulHit(int score)
    {
        totalScore += score;
    }

    public void Miss()
    {
        dgm.DamageDemonLord(1);

        healthBar.localScale = new Vector3(dgm.demonLordHealth / maxHealth, 1, 1);
    }

    public int UpdateScore()
    {
        //for (int i = 0; i < note.Length; i++)
        //{
        //    totalScore += note[i].gameObject.GetComponent<RhythmicNote>().currentScore;
        //}

        Debug.Log(totalScore);
        return totalScore;
    }
}// end of script
