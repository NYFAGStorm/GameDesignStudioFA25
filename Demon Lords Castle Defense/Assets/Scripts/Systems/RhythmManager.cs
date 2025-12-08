using UnityEngine;
using UnityEngine.Events;

public enum OnBeat
{
    OnOne,
    OnTwo,
    OnThree,
    OnFour
}

public class RhythmManager : MonoBehaviour
{
    private float secondTimer = 0;
    private int beat = 1;

    private void FixedUpdate()
    {
        float timeIncrement = Time.fixedDeltaTime * (Rhythm.beatsPerMinute / 60);

        secondTimer = Mathf.Min(1, secondTimer + timeIncrement);

        if (secondTimer >= 1)
        {
            Rhythm.beats[0].Invoke();
            secondTimer = 0;
            beat++;

            if (beat == 2 || beat == 4)
            {
                Rhythm.beats[1].Invoke();
            }

            if (beat == 3) Rhythm.beats[2].Invoke();
        }
    }
}

public static class Rhythm
{
    private static UnityEvent Beat = new UnityEvent();
    private static UnityEvent SecondBeat = new UnityEvent();
    private static UnityEvent ThirdBeat = new UnityEvent();
    private static UnityEvent FourthBeat = new UnityEvent();

    public static float beatsPerMinute = 60;
    public static UnityEvent[] beats = { Beat, SecondBeat, ThirdBeat, FourthBeat };
}

