using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class LvlUpUISystem : IEcsRunSystem {
        
        private readonly EcsFilter<Lvl, LvlUpUIUpdater, LvlUpgradedFlag> _filter = null;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref Lvl lvl = ref _filter.Get1(i);
                ref LvlUpUIUpdater ui = ref _filter.Get2(i);
                ui.lvlupView.SetLvlParametrs(lvl.current, lvl.price);
            }
        }
    }
}