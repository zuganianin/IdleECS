using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoreLogic.Business.Configs {
    
    [CreateAssetMenu(fileName = "Business Config", menuName = "Business/Business Config")]
    public class BusinessConfig : ScriptableObject
    {
        public string businesName = "business";
        public float incomeCoolDown = 3.0f;
        public int basePrice = 3;
        public int baseIncome = 3;
        public BusinessUpgrade[] upgrades;
    }
}