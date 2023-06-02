using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeDataView : MonoBehaviour, IUpgradeDataView
{
    [SerializeField]
    private TMP_Text _title;

    [SerializeField]
    private TMP_Text _bust;

    [SerializeField]
    private TMP_Text _price;
    
    public void FillData(string nameUpgrade, float bust)
    {
        _title.text = nameUpgrade;
        _bust.text = $"Доход: + {bust}%";
    }

    public void SetPrice(int price)
    {
        _price.text = (price > 0) ? $"Цена: {price}$" : "Куплено";
    }
}
