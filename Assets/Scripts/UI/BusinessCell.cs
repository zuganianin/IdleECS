using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Leopotam.Ecs;
using System;

public enum BusinessCellButtonType
{
    Lvlup = 0,
    upgrade1,
    upgrade2
}
public class BusinessCell : MonoBehaviour, IProgress, IIncomeView, ILvlUpView
{
    public event Action<int,BusinessCellButtonType> ButtonCellTaped;
    [SerializeField]
    private TMP_Text _title;

    [SerializeField]
    private TMP_Text _lvl;

    [SerializeField]
    private TMP_Text _income;

    [SerializeField]
    private ProgressBar _progress;

    [SerializeField]
    private TMP_Text _lvlupPrice;

    [SerializeField]
    private UpgradeDataView _up1;

    [SerializeField]
    private UpgradeDataView _up2;

    private int _id;

    public void Initialize(int id)
    {
        _id = id;
    }

    public void ButtonTaped(int index)
    {
        ButtonCellTaped?.Invoke(_id,(BusinessCellButtonType)index);
    }

    public void SetProgress(float progress)
    {
        _progress.SetProgress(progress);
    }

    public void SetNameBusines(string nameBusines)
    {
        _title.text = nameBusines;
    }

    public void SetIncomeValue(int income)
    {
        _income.text = income.ToString();
    }

    public void SetLvlParametrs(int lvl, int price)
    {
        _lvl.text = lvl.ToString();
        _lvlupPrice.text = price.ToString();
    }

}
