using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;
public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private float startingGold;
    private float money;
    [SerializeField] private float roundGold;//amount to increase each round
   [SerializeField] private float noDamageBonus;//bonus if no damage on mother plant

    void Awake()
    {
        AudioManager.instance.PlayMusic("CALM2");
        money = startingGold; 
        instance = this;
        UpdateUI();
    }
    public bool TryBuy(float amount)
    {
        if(money < amount)return false;//cant buy
        money = MathF.Max(money-amount, 0);
        UpdateUI();
        return true;

    }
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }
    public void EndOfRoundGold()
    {
        AddMoney((int)roundGold);
    }

    public void EndOfRoundBonus()
    {
        AddMoney((int)noDamageBonus);
    }

    void UpdateUI()
    {
        currencyText.text = $"$ {money.ToString("0")}";
    }
}


//-- how would i check that lol
//-- would need to check the amount beore the wave?
//funtion to raise money
//-- increase by a certain amount
//function to decrease money
//-- check if u can decrease
//-- if so decrease 
//-- if it doesnt decrease set off not enough event

