using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class LvlUpgradeRunSystem : IEcsRunSystem {
        
        readonly RuntimeData _runtimeData = null;
        readonly LvlPriceCalculator _calc = null;
        readonly EcsWorld _world = null;
        private readonly EcsFilter<Lvl, Income, LvlUpgradedFlag> _filter = null;


        void IEcsRunSystem.Run () {

            if(_filter.IsEmpty())
            {
                return;
            }
            bool needMoneyUIUpdate = false;

            foreach (var i in _filter)
            {
                ref Lvl lvl = ref _filter.Get1(i);
                if(lvl.price <= _runtimeData.Money)
                {
                    _runtimeData.Money -= lvl.price;
                    needMoneyUIUpdate = true;

                    ref EcsEntity entity = ref _filter.GetEntity (i);
                    if(lvl.current == 0)
                    {
                        entity.Get<ActiveBusinessFlag>();
                    }
                    UpgradeLvl(ref lvl);
                    entity.Get<LvlUpdateUIFlag>();

                    
                    ref Income income = ref _filter.Get2(i);
                }
            }
            if(needMoneyUIUpdate)
            {
                _world.NewEntity().Get<MoneyUpdateRequest>();
            }
        }

        private void UpgradeLvl(ref Lvl lvl)
        {
            lvl.current += 1;
            lvl.price = _calc.PriceForLevel(lvl);
        }
    }
}