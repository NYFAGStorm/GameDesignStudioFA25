using UnityEngine;

public class Popup : MonoBehaviour
{
    private GameObject[] statLines;

    public GameObject popupStatBase;
    public GameObject popupButtonBase;

    public void BuildPopup(PopupBlueprint blueprint)
    {
        
    }
    
    public void Delete()
    {
        Destroy(gameObject);
    }
}