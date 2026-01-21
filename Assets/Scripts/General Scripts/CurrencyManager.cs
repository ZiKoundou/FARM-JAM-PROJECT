using UnityEngine;
using System;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private float startingGold;
    private float currentGold;
    [SerializeField] private float roundGold;//amount to increase each round
    private float noDamageBonus;//bonus if no damage on mother plant

    void Awake()
    {
       currentGold = startingGold; 
    }
    public bool TryBuy(float amount)
    {
        if(currentGold > amount)
        {
            currentGold = MathF.Max(currentGold-amount, 0);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EndOfRoundGold()
    {
        currentGold += roundGold;
    }
    public void EndOfRoundBonus()
    {
        currentGold += noDamageBonus;
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

