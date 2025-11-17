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
    }
}
