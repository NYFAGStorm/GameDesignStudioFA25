using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    private GameObject[] statLines;

    public GameObject popupStatBase;
    public GameObject popupButtonBase;
    public TMP_Text header;

    public void BuildPopup(PopupBlueprint blueprint)
    {
        header.text = blueprint.header;
    }
    
    public void Delete()
    {
        Destroy(gameObject);
    }
}