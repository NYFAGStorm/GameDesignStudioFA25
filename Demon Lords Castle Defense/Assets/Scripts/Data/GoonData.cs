using UnityEngine;
using UnityEngine.Events;

// Author: Gustavo Rojas Flores
// Manages all types and enums relating to Goons


public enum GoonType
{
    Goblin,
    Imp,
    Hellhound,
    Bat,
    Slime
}

public class GoonData : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent ExistingGoonsUpdated;
    public GameObject goonBase;
    public UniqueGoons types;

    public void DEBUGGoon()
    {
        CreateGoon(GoonType.Goblin);
    }

    public Goon CreateGoon(GoonType type)
    {
        UniqueGoon goonData = new UniqueGoon();

        foreach (UniqueGoon ug in types.goons)
        {
            if (ug.type == type)
            {
                goonData = ug;
                break;
            }
        }

        Goon newGoon = Instantiate(goonBase).GetComponent<Goon>();
        newGoon.InitializeGoon(goonData);

        ExistingGoonsUpdated.Invoke();

        return newGoon;
    }
}
