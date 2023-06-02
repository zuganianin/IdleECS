using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using TMPro;
public class BusinesView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _moneyText;

    [SerializeField]
    private BusinessCell _cellPrototype;

    [SerializeField]
    private Transform _parentTransformForCells;

    private List<BusinessCell> _allCells;
   
    public void Initialize()
    {
    }

    public BusinessCell GetCell(int id)
    {
        var cell = Instantiate<BusinessCell>(_cellPrototype);
        cell.Initialize(id);
        cell.gameObject.transform.SetParent(_parentTransformForCells);
        return cell;
    }

    public void UpdateMoneyText(int moneyCount)
    {
        _moneyText.text = $"Баланс: {moneyCount}$";
    }

}
