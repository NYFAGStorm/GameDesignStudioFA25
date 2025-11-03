using TMPro;
using UnityEngine;

public class CurrencyDisplay : MonoBehaviour
{
    public TMP_Text display;

}

public static class CurrencyManager
{
    private static int bankedSouls;

    public static bool SpendSouls(int price)
    {
        bool canSpend = bankedSouls >= price;
        
        if (canSpend)
        {
            bankedSouls -= price;
        }
        
        return canSpend;
    }

    public static void AwardSouls(int reward)
    {
        bankedSouls += reward;
    }

    public static int SoulBalance()
    {
        return bankedSouls;
    }
}
