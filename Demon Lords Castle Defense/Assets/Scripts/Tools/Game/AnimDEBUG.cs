using UnityEditor;
using UnityEngine;

public class AnimDEBUG : MonoBehaviour
{
    public GoblinSpriteAnimation animationScript;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animationScript.SetCurrentAnim(GoblinSpriteAnimation.AnimSet.Attack);

            //gameObject.SetActive(false);
        }
    }
}
