using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class LvlUpgradeRunSystem : IEcsRunSystem {
        
        readonly LvlPriceCalculator _calc = null;
        readonly EcsWorld _world = null;

        void IEcsRunSystem.Run () {
            // Цена уровня = cost = (lvl+1) * базовая_стоимость
        }
    }
}