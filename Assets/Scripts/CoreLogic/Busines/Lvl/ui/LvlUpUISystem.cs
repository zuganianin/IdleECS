using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class LvlUpUISystem : IEcsRunSystem {
        
        readonly EcsWorld _world = null;

        private readonly EcsFilter<Lvl,LvlUpgradeFlag> _filter = null;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref Lvl lvl = ref _filter.Get1(i);
            }
        }


    }
}