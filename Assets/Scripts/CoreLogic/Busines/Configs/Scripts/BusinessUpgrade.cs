using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BusinessUpgrade
{
   public string upgradeName = "up";
   public int price = 10;
   
   [Header("Множитель дохода в %")]
   public float bust = 10;
}
