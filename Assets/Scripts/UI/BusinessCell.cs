using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Leopotam.Ecs;
public class BusinessCell : MonoBehaviour, IProgress, IIncomeView
{
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
    
   
    void Start()
    {
        
    }

    public void ButtonTaped(int index)
    {

    }

    public void SetProgress(float progress)
    {
        _progress.SetProgress(progress);
    }

    public void SetNameBusines(string nameBusines)
    {
        _title.text = nameBusines;
    }

    public void SetIncome(int income)
    {
        _income.text = income.ToString();
    }
}
