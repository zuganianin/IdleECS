using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreLogic.Business;
public class LvlPriceCalculator 
{
    public int PriceForLevel(Lvl lvl)
    {
        return PriceForLevel(lvl.current, lvl.basePrice);
    }
    public int PriceForLevel(int lvl, int basePrice)
    {
        return (lvl + 1) * basePrice;
    }
}
