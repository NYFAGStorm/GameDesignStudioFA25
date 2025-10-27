using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static GameObject popupBase;

}

public struct statLine
{
    public string statName;
    public float value;
}

public struct PopupBlueprint
{
    public statLine[] stats;
}

public static class Popup
{
    public static GameObject CreatePopup(PopupBlueprint blueprint)
    {
        GameObject newPopup = Object.Instantiate(PopupManager.popupBase);

        return newPopup;
    }
}