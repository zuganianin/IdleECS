using Leopotam.Ecs;
using Scripts.Services;

namespace CoreLogic.Business {
    sealed class BusinessLoadInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly ILoader _loadService;
        readonly RuntimeData _runtimeData;
        private readonly EcsFilter<Identificator, Upgrade> _upgradeFilter = null;
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
                    if(lvl.current > 0)
                    {
                        ref EcsEntity entity = ref _businessFilter.GetEntity(i);
                        entity.Get<ActiveBusinessFlag>();
                    }
                    ref IncomeProgress progress = ref _businessFilter.Get3(i);
                    progress.current = data.currentProgress;
                }
            }

            foreach (var i in _upgradeFilter)
            {
                ref Identificator id = ref _upgradeFilter.Get1(i);
                ref Upgrade up = ref _upgradeFilter.Get2(i);
                var buyed = _loadService.Load<bool>($"upgr{up.businessId}_{id.id}");
                up.isBuyed = buyed;
                if(buyed)
                {
                    ref EcsEntity upgradeEntity = ref _upgradeFilter.GetEntity(i);
                    upgradeEntity.Get<UpgradeBuyedFlag>();
                    upgradeEntity.Get<UpdateUpgradeUIFlag>();
                 
                    ref EcsEntity businesEntity = ref _runtimeData.GetEntity(up.businessId);
                    ref IncomeBust bust = ref businesEntity.Get<IncomeBust>();
                    bust.bust += up.bust;
                }
            }
        }
    }
}