using Leopotam.Ecs;
using CoreLogic.Business;

public class UiEventToEntity
{
    private EcsEntity[] _businessEntities;
    private EcsEntity[,] _upgradesEntities;

    public void Initialize(EcsEntity[] business, EcsEntity[,] upgrades)
    {
        _businessEntities = business;
        _upgradesEntities = upgrades;
    }

    public void CellIndexButtonTap(int index, BusinessCellButtonType type)
    {
        switch(type)
        {
            case BusinessCellButtonType.Lvlup: {
                _businessEntities[index].Get<TryBuyLvlUpFlag>();
                break;
            }
            default : 
            {
                int upgradeIdx = (int)type - 1;
                var upgrade = _upgradesEntities[index,upgradeIdx];
                var busines = _businessEntities[index];

                if(!upgrade.IsAlive())
                {
                    return;
                }

                upgrade.Get<TryBuyUpgradeFlag>();
                busines.Get<TryBuyUpgradeFlag>();
                break;
            }
        }
    }
}
