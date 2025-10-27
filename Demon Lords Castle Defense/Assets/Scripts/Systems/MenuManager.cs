using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles menus, including switching scenes

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}// end of script
