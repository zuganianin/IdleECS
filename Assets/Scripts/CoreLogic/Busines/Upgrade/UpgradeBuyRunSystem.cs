using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class UpgradeBuyRunSystem : IEcsRunSystem {
        readonly RuntimeData _runtimeData = null;
        readonly EcsWorld _world = null;
        private readonly EcsFilter<Upgrade, TryBuyUpgradeFlag>.Exclude<UpgradeBuyedFlag> _upgradeFilter = null;
        
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
                    ref EcsEntity businesEntity = ref _runtimeData.GetEntity(upgrade.businessId);
                    ref IncomeBust bust = ref businesEntity.Get<IncomeBust>();
                    bust.bust += upgrade.bust;
                    businesEntity.Get<IncomeUpgradedFlag>();

                    _runtimeData.Money -= upgrade.price;
                    needMoneyUIUpdate = true;

                    ref EcsEntity upgradeEntity = ref _upgradeFilter.GetEntity(i);
                    upgradeEntity.Get<UpgradeBuyedFlag>();
                    upgradeEntity.Get<UpdateUpgradeUIFlag>();
                    upgrade.isBuyed = true;
                }
            }
            if(needMoneyUIUpdate)
            {
                _world.NewEntity().Get<MoneyUpdateRequest>();
            }
        }
    }
}