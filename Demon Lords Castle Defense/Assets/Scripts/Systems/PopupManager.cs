using UnityEngine;

public class PopupManager : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages creation of popups

    public GameObject popupBase;
}

// Written Rule (Esther)
// if clicking on an item (hero, tile, trophy, goon)
//  highlight said item
//  show tooltip on the top of said item
//      - if Hero, box follow hero
//      - if goon/trophy/tile, when item is dragged away, box disappear
//      - clicking away (on black space, on another item), box disappear
//  data shown (Hero):
//      - Name
//      - Speed
//      - Current HP / Total HP
//      - Damage
//      - Attack on _____ beat
//      - Range: Melee or Range
//      - Attribute
//  data shown (Tile):
//      - Name
//      - Level
//      - Damage
//      - Attack on _____ beat
//      - Attribute
//      - Available slots
//  data shown (Goon):
//      - Name
//      - Current HP / Total HP
//      - Damage
//      - Attack on _____ beat
//      - Range: Melee or Range
//      - Attribute
//  data shown (Trophy):
//      - Name
//      - Description

public struct PopupLabel
{
    public string text;
    public string identifier;
    public Vector2 size;
    public Vector2 position;
}

public struct PopupButton
{
    public string buttonText;
    public Sprite buttonImage;
    public Vector2 size;
    public Vector2 position;
}

public struct PopupBlueprint
{
    public Transform target;
    public Vector2 size;
    public Vector2 position;
    public string header;
    public PopupLabel[] labels;
    public string[] buttons;
}

public static class PopupBuilder
{
    public static Popup CreatePopup(PopupBlueprint blueprint)
    {
        Popup newPopup = Object.Instantiate(Object.FindFirstObjectByType<PopupManager>().popupBase).GetComponent<Popup>();
        newPopup.BuildPopup(blueprint);

        return newPopup;
    }
}