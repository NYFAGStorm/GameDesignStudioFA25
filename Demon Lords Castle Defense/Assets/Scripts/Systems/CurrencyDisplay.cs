using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyDisplay : MonoBehaviour
{
    public TMP_Text display;

    public UnityEvent CurrencyUpdated;

    private void Awake()
    {
        CurrencyUpdated.AddListener(UpdateDisplay);

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        display.text = CurrencyManager.SoulBalance() + "";
    }
}

public static class CurrencyManager
{
    private static int bankedSouls = 100;

    public static bool SpendSouls(int price)
    {
        bool canSpend = bankedSouls >= price;
        
        if (canSpend)
        {
            bankedSouls -= price;

            Object.FindFirstObjectByType<CurrencyDisplay>().CurrencyUpdated.Invoke();
        }
        
        return canSpend;
    }

    public static void AwardSouls(int reward)
    {
        bankedSouls += reward;

        Object.FindFirstObjectByType<CurrencyDisplay>().CurrencyUpdated.Invoke();
    }

    public static int SoulBalance()
    {
        return bankedSouls;
    }
}
