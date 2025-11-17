using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NYFA Studio/Utility/AnimSprite")]
public class AnimSprite : MonoBehaviour
{
    // Author: Glenn Storm
    // This handles simple sprite animation (loops or play once)
    // This is modified to work with animation sets

    public enum AnimSet
    {
        Idle,
        Attack,
        Hurt,
        Death
    }
    public AnimSet currentAnim;

    public Sprite[] idleSprites;
    public Sprite[] attackSprites;
    public Sprite[] hurtSprites;
    public Sprite[] deathSprites;

    private Sprite[] sprites;

    public bool loop;
    public float frameInterval = 0.25f;
    [Tooltip("If true, will deactivate this tool to be re-used. If false, will disable this tool.")]
    public bool resetOnComplete;

    private SpriteRenderer r;
    private bool valid;
    private int currentFrame;
    private float frameTimer;

    const float MINFRAMEINTERVAL = 0.001f;


    void OnEnable()
    {
        if (valid)
        {
            currentFrame = 0;
            frameTimer = frameInterval;
        }
    }

    void Start()
    {
        // validate
        r = gameObject.GetComponent<SpriteRenderer>();
        if ( r == null )
        {
            Debug.LogError("--- AnimSprite [Start] : "+gameObject.name+" no sprite renderer attached. aborting.");
            enabled = false;
        }
        if (idleSprites == null || idleSprites.Length == 0 )
        {
            Debug.LogError("--- AnimSprite [Start] : " + gameObject.name + " no idle sprites configured. aborting.");
            enabled = false;
        }
        if ( frameInterval <= 0f )
        {
            Debug.LogWarning("--- AnimSprite [Start] : " + gameObject.name + " invalid frame interval. will set to "+ MINFRAMEINTERVAL + ".");
            frameInterval = MINFRAMEINTERVAL;
        }
        // initialize
        if ( enabled )
        {
            valid = true;
            frameTimer = frameInterval;
        }
    }


    void Update()
    {
        if ( frameTimer > 0f )
        {
            frameTimer -= Time.deltaTime;
            if ( frameTimer < 0f )
            {
                if (frameInterval > 0f)
                    frameTimer = frameInterval;
                else
                    frameTimer = MINFRAMEINTERVAL;
                currentFrame++;
                if ( currentFrame >= sprites.Length )
                {
                    currentFrame = 0;
                    if (!loop)
                    {
                        frameTimer = 0f;
                        if (currentAnim != AnimSet.Death)
                        {
                            // if not death, set to idle and loop
                            SetCurrentAnim(AnimSet.Idle);
                        }
                        else
                        {
                            if (resetOnComplete)
                                gameObject.SetActive(false);
                            else
                                enabled = false;
                        }
                    }
                }
                r.sprite = sprites[currentFrame];
            }
        }
    }

    /// <summary>
    /// This sets the current animation immediately
    /// </summary>
    /// <param name="current">the animation set</param>
    public void SetCurrentAnim(AnimSet current)
    {
        if (current == currentAnim)
            return;
        currentAnim = current;
        loop = (current == AnimSet.Idle);
        currentFrame = 0;
    }

    /// <summary>
    /// This sets the time between frames (in seconds)
    /// </summary>
    /// <param name="newInterval">interval in seconds</param>
    public void SetFrameInterval( float newInterval )
    {
        frameInterval = newInterval;
        frameTimer = Mathf.Min(frameTimer, frameInterval);
    }
}
