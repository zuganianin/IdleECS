using UnityEngine;
using UnityEditor;

namespace CoreLogic.Business.Configs {
    [CustomEditor(typeof(CurrentConfig))]
    public class CurrentConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CurrentConfig config = (CurrentConfig)target;
            BusinessConfig[] allBusiness = config.data.allBusiness;
            int i = 1;
            foreach (var bis in allBusiness)
            {
                bis.businesName = TextField($"{i} Имя биз:",bis.businesName,0);
                int j = 1;
                foreach (var upgrade in bis.upgrades)
                {
                    GUILayout.Space(2);
                    upgrade.upgradeName = TextField($"{j} Улуч.:",upgrade.upgradeName,8);
                    j++;
                }
                GUILayout.Space(8);
                i++;
            }
        }

        private string TextField(string name, string content, int leftSpace)
        {
            GUILayout.BeginHorizontal();
            if(leftSpace>0)
            {
                GUILayout.Space(leftSpace);
            }
            var style = new GUIStyle(GUI.skin.label);
            style.alignment = TextAnchor.UpperCenter;
            style.fixedWidth = 70;
            GUILayout.Label(name, style);

            var result = GUILayout.TextField(content, 25);
            GUILayout.EndVertical();
            return result;
        }
    }
}
