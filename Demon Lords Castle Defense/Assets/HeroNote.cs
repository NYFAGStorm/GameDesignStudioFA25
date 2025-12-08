using UnityEngine;

public class HeroNote : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Controls an individual note

    private int lane;
    private float speed;
    private RectTransform rect;
    private float distance = 0;
    private KeyCode noteKey;
    private float targetPosition;
    private float threshold;
    private float outOfBounds = 200;

    public void InitializeNote(int inLane, float inSpeed, float inTarget, float inThreshold)
    {
        lane = inLane;
        speed = inSpeed;
        rect = GetComponent<RectTransform>();
        targetPosition = inTarget;
        threshold = inThreshold;

        switch (lane)
        {
            case 0:
                noteKey = KeyCode.A;
                break;
            case 1:
                noteKey = KeyCode.S;
                break;
            case 2:
                noteKey = KeyCode.D;
                break;
            case 3:
                noteKey = KeyCode.F;
                break;
        }
    }

    void Update()
    {
        rect.anchoredPosition -= new Vector2(0, -speed);

        distance += speed;

        if (Input.GetKeyDown(noteKey) && Mathf.Abs(distance - targetPosition) < threshold)
        {
            FindFirstObjectByType<RhythmGameManager>().SuccessfulHit(100);

            Destroy(gameObject);
        }

        if (distance > outOfBounds)
        {
            Destroy(gameObject);
        }
    }
}
