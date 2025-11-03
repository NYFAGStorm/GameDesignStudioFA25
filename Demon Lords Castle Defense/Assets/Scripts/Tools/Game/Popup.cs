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
        canvas.GetComponent<RectTransform>().sizeDelta = blueprint.size;

        PopupBuilder.DestroyOtherPopups.AddListener(Delete);


        foreach (PopupLabel label in blueprint.labels)
        {
            RectTransform newLabel = Instantiate(labelBase, canvas).GetComponent<RectTransform>();
            newLabel.anchoredPosition = label.position;
            newLabel.sizeDelta = label.size;
            newLabel.GetComponent<TMP_Text>().text = label.text;
            newLabel.GetComponent<TMP_Text>().fontSize = label.textScale;
            newLabel.gameObject.name = label.identifier;
        }

        if (blueprint.buttons != null)
        {
            foreach (PopupButton button in blueprint.buttons)
            {
                RectTransform newButton = Instantiate(labelBase, canvas).GetComponent<RectTransform>();
                newButton.anchoredPosition = button.position;
                newButton.sizeDelta = button.size;
                TMP_Text label = newButton.transform.GetChild(0).GetComponent<TMP_Text>();
                label.text = button.text;
                label.fontSize = button.textScale;
                newButton.GetComponent<Button>().onClick.AddListener(button.action);

                if (button.image) newButton.GetComponent<Image>().sprite = button.image;
            }
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