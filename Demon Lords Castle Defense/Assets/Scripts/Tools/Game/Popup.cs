using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages popup functionality

    private TMP_Text[] labels;
    private Button[] buttons;

    public GameObject labelBase;
    public GameObject popupButtonBase;
    public TMP_Text header;
    public Transform canvas;

    public void BuildPopup(PopupBlueprint blueprint)
    {
        header.text = blueprint.header;
        
        foreach (PopupLabel label in blueprint.labels)
        {
            RectTransform newLabel = Instantiate(labelBase, canvas).GetComponent<RectTransform>();
            newLabel.anchoredPosition = label.position;
            newLabel.sizeDelta = label.size;
            newLabel.GetComponent<TMP_Text>().text = label.text;
            newLabel.gameObject.name = label.identifier;
        }
    }

    public void UpdateLabel(string id, string newText)
    {
        foreach (TMP_Text label in labels)
        {
            if (label.gameObject.name == id) label.text = newText;
        }
    }
    
    public void Delete()
    {
        Destroy(gameObject);
    }
}