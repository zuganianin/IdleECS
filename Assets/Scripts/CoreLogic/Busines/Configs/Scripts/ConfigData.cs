using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLogic.Business.Configs {

    [CreateAssetMenu(fileName = "ConfigData", menuName = "Business/Config Data Variant")]
    public class ConfigData : ScriptableObject
    {
        public BusinessConfig[] allBusiness;
    }
}
