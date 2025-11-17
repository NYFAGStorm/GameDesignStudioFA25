using UnityEngine;

public class AnimDEBUG : MonoBehaviour
{
    public AnimSprite animationScript;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animationScript.SetCurrentAnim(AnimSprite.AnimSet.Attack);

            //gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            animationScript.SetCurrentAnim(AnimSprite.AnimSet.Hurt);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            animationScript.SetCurrentAnim(AnimSprite.AnimSet.Death);
        }
    }
}
