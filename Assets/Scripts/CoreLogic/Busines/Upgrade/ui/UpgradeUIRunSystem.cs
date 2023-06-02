using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class UpgradeUIRunSystem : IEcsRunSystem {
        
        private readonly EcsFilter<Upgrade, UpgradeUIUpdater, UpdateUpgradeUIFlag> _filter = null;

        void IEcsRunSystem.Run () {
            foreach(var i in _filter)
            {
                ref Upgrade upgrade = ref _filter.Get1(i);
                ref UpgradeUIUpdater view = ref _filter.Get2(i);
                ref EcsEntity upgradeEntity = ref _filter.GetEntity(i);

                if(upgrade.isBuyed)
                {
                    view.view.SetPrice(0);
                }
                else 
                {
                    view.view.SetPrice(upgrade.price);
                }
                
            }
        }
    }
}