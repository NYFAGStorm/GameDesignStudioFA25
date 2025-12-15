using UnityEngine;

// Author: Gustavo Rojas Flores
// Manages all types and enums relating to Tiles

public enum TrophyType
{
    StarShield
}

public class TrophyData : MonoBehaviour
{
    public GameObject TrophyBase;
    public UniqueTrophies types;

    public Trophy CreateTrophy(TrophyType type)
    {
        GameObject newTrophyObject = Instantiate(TrophyBase);
        UniqueTrophy trophyData = new UniqueTrophy();

        foreach (UniqueTrophy t in types.trophies)
        {
            if (t.type == type)
            {
                trophyData = t;
                break;
            }
        }
        
        Trophy newTrophy = newTrophyObject.GetComponent<Trophy>();
        newTrophy.InitializeTrophy(trophyData);

        return newTrophy;
    }
}
