using UnityEditor;
using UnityEngine;

public class AnimDEBUG : MonoBehaviour
{
    public AnimSprite animationScript;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animationScript.SetCurrentAnim(AnimSprite.AnimSet.Attack);

            //gameObject.SetActive(false);
        }
    }
}
