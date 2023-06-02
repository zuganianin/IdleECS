using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BusinessSaveData 
{
    public int lvl;
    public float currentProgress;

    public BusinessSaveData(int lvl, float currentProgress)
    {
        this.lvl = lvl;
        this.currentProgress = currentProgress;
    }
}
