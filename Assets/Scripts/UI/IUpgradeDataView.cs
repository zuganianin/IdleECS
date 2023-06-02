using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeDataView
{
    public void FillData(string nameUpgrade, float bust);
    public void SetPrice(int price);
}
