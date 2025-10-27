using UnityEngine;
using UnityEngine.Events;

public class RhythmManager : MonoBehaviour
{
    private float secondTimer = 0;

    private void FixedUpdate()
    {
        float timeIncrement = Time.fixedDeltaTime * (Rhythm.beatsPerMinute / 60);

        secondTimer = Mathf.Min(1, secondTimer + timeIncrement);

        if (secondTimer == 1)
        {
            Rhythm.FullBeat.Invoke();
            Rhythm.HalfBeat.Invoke();
            Rhythm.QuarterBeat.Invoke();

            secondTimer = 0;
        }
    }
}

public static class Rhythm
{
    public static float beatsPerMinute = 120;
    public static UnityEvent FullBeat = new UnityEvent();
    public static UnityEvent HalfBeat = new UnityEvent();
    public static UnityEvent QuarterBeat = new UnityEvent();
}

