using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class UpgradeBuyRunSystem : IEcsRunSystem {
        readonly RuntimeData _runtimeData = null;
        readonly EcsWorld _world = null;
        private readonly EcsFilter<Upgrade, TryBuyUpgradeFlag> _upgradeFilter = null;
        private readonly EcsFilter<Identificator, IncomeBust, TryBuyUpgradeFlag> _incomeFilter = null;
        
        void IEcsRunSystem.Run () {

            if(_upgradeFilter.IsEmpty())
            {
                return;
            }
            bool needMoneyUIUpdate = false;

            foreach (var i in _upgradeFilter)
            {
                ref Upgrade upgrade = ref _upgradeFilter.Get1(i);
                if(upgrade.price <= _runtimeData.Money)
                {
                    foreach (var j in _incomeFilter)
                    {
                        ref Identificator ident = ref _incomeFilter.Get1(j);
                        if(ident.id != upgrade.businessId)
                        {
                            continue;
                        }
                        ref IncomeBust bust = ref _incomeFilter.Get2(j);
                        bust.bust += upgrade.bust;

                        ref EcsEntity incomeEntity = ref _incomeFilter.GetEntity(j);
                        incomeEntity.Get<IncomeUpgradedFlag>();

                        _runtimeData.Money -= upgrade.price;
                        needMoneyUIUpdate = true;

                        ref EcsEntity upgradeEntity = ref _upgradeFilter.GetEntity(i);
                        
                        upgradeEntity.Get<UpgradeBuyedFlag>();
                        upgradeEntity.Get<UpdateUpgradeUIFlag>();
                        upgradeEntity.Get<DeleteMark>();
                        break;
                    }
                }
            }
            if(needMoneyUIUpdate)
            {
                _world.NewEntity().Get<MoneyUpdateRequest>();
            }
        }
    }
}