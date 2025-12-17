using UnityEngine;

public class Credits : MonoBehaviour
{
    //Author: Esther Li
    // this handles the credits

    public GameObject credits;

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }
}
