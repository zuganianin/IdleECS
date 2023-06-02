using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using CoreLogic.Business;

public class UiEventToEntity
{
    private EcsEntity[] _entities;
    public void Initialize(EcsEntity[] entities)
    {
        _entities = entities;
    }

    public void CellIndexButtonTap(int index, BusinessCellButtonType type)
    {
        switch(type)
        {
            case BusinessCellButtonType.Lvlup: {
                _entities[index].Get<LvlUpUserTapFlag>();
                break;
            }
            case BusinessCellButtonType.upgrade1: {
                break;
            }
            case BusinessCellButtonType.upgrade2: {
                break;
            }
        }
    }
}
