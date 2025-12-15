using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Author: Esther Li
    // Pauses the game

    public GameObject pauseClose;
    public GameObject pauseOpen;
    public GameObject tutorial;
    public GameObject shopOpen;
    public GameObject shopClose;

    private bool isPaused = false;
    private float counter = 0.5f;

    private void Update()
    {
        //open the pause menu when [ESC] is pressed
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            OpenPauseMenu();
        }
    }

    public void OpenPauseMenu()
    {
        if (isPaused) return;

        isPaused = true;

        pauseClose.SetActive(true);
        // deactivate the shop and tutorial that can react to clicks
        shopClose.GetComponent<Button>().interactable = false;
        shopOpen.GetComponent<Button>().interactable = false;
        tutorial.GetComponent<TutorialManager>().enabled = false;
        // simple animation purpose
        StartCoroutine(OpenPause());
    }

    IEnumerator OpenPause()
    {
        yield return new WaitForSeconds(counter);
        pauseClose.SetActive(false);
        pauseOpen.SetActive(true);
        
        // this exist here so the coroutine can work
        Time.timeScale = 0;
    }

    IEnumerator ClosePause()
    {
        yield return new WaitForSeconds(counter);
        pauseClose.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        pauseOpen.SetActive(false);
        pauseClose.SetActive(true);

        shopClose.GetComponent<Button>().interactable = true;
        shopOpen.GetComponent<Button>().interactable = true;
        tutorial.GetComponent<TutorialManager>().enabled = true;

        StartCoroutine(ClosePause());
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
