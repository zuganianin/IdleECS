using Leopotam.Ecs;
using Scripts.Services;

namespace CoreLogic.Business {
    sealed class BusinessLoadInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly ILoader _loadService;
        readonly RuntimeData _runtimeData;

        // Identificator
        // Lvl
        // IncomeProgress

        //upgrades
        //Upgrade

        private readonly EcsFilter<Upgrade, TryBuyUpgradeFlag> _upgradeFilter = null;
        private readonly EcsFilter<Identificator, Lvl, IncomeProgress> _businessFilter = null;
        
        public void Init () {
            _runtimeData.Money = _loadService.Load<int>(Constants.MoneyPath);
            foreach (var i in _businessFilter)
            {
                ref Identificator id = ref _businessFilter.Get1(i);
                var data = _loadService.Load<BusinessSaveData>($"business_{id.id}");
                if(data != null)
                {
                    ref Lvl lvl = ref _businessFilter.Get2(i);
                    lvl.current = data.lvl;

                    ref IncomeProgress progress = ref _businessFilter.Get3(i);
                    progress.current = data.currentProgress;
                }
            }
        }
    }
}