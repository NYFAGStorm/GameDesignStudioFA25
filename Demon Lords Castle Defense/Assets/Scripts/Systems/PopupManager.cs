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
    public Transform target;
    public Vector2 size;
    public Vector2 position;
    public statLine[] stats;
    public string[] buttons;
}

public static class PopupBuilder
{
    public static Popup CreatePopup(PopupBlueprint blueprint)
    {
        Popup newPopup = Object.Instantiate(PopupManager.popupBase).GetComponent<Popup>();
        newPopup.BuildPopup(blueprint);

        return newPopup;
    }
}