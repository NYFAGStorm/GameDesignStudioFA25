using UnityEngine;

[System.Serializable]
public struct UniquePower
{
    public PowerType type;
    public float coolDownTime;
    public BoostPattern pattern;
    // power effect
    // boost effect
}

public enum PowerType
{
    ApplaudMe,
    TouchUp,
    FashionPolice,
    FloorIsLava,
    DiscoInferno,
    YouCallThatAFight
}

public enum BoostPattern
{
    A,
    B,
    C,
    D,
    E,
    F
}
public class PowerData : MonoBehaviour
{
    public UniquePower[] powerList;

    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}// end of class
