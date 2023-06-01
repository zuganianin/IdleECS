using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeDataView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;

    [SerializeField]
    private TMP_Text _bust;

    [SerializeField]
    private TMP_Text _price;
    
    public void FillData()
    {
        // _bust.text = $"Доход: + {part1}%";
    }
}
