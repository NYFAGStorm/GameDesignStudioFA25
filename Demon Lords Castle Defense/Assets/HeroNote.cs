using UnityEngine;

public class HeroNote : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Controls an individual note

    private int lane;
    private float speed;
    private RectTransform rect;
    private KeyCode noteKey;
    private RectTransform targetPosition;
    private RectTransform missPosition;
    private float threshold;

    public void InitializeNote(int inLane, float inSpeed, float inThreshold, RectTransform inTarget, RectTransform inMiss)
    {
        lane = inLane;
        speed = inSpeed;
        rect = GetComponent<RectTransform>();
        targetPosition = inTarget;
        threshold = inThreshold;
        missPosition = inMiss;

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
        rect.anchoredPosition -= new Vector2(0, speed * Time.deltaTime);

        if (Input.GetKeyDown(noteKey) && Vector2.Distance(rect.position, targetPosition.position) < threshold)
        {
            FindFirstObjectByType<RhythmGameManager>().SuccessfulHit(100);

            Destroy(gameObject);
        }

        Debug.Log(Vector2.Distance(rect.position, missPosition.position));
        if (Vector3.Distance(rect.position, missPosition.position) < threshold)
        {
            Destroy(gameObject);
        }
    }
}
