using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLogic.Business.Configs {
    
    [CreateAssetMenu(fileName = "ConfigDataEdir", menuName = "Business/Config Data name Edit")]
    public class CurrentConfig : ScriptableObject
    {
        public ConfigData data;
    }
}
