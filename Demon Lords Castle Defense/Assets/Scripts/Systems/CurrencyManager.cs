using UnityEngine;

public static class CurrencyManager
{
    private static float bankedSouls;

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
}
