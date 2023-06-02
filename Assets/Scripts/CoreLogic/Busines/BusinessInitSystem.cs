using Leopotam.Ecs;
using CoreLogic.Business;
using CoreLogic.Business.Configs;

namespace CoreLogic.Business {
    sealed class BusinessInitSystem : IEcsInitSystem {
        readonly EcsWorld _world = null;
        readonly ConfigData _config = null;
        readonly BusinesView _view = null;
        readonly LvlPriceCalculator _lvlCalc;
        private EcsEntity[] _businessEntities;
        private EcsEntity[,] _upgrades;
        private UiEventToEntity _eventToEntity;
        
        public void Init () {
            
            _eventToEntity = new UiEventToEntity();
            _businessEntities = new EcsEntity[_config.allBusiness.Count];
            _upgrades = new EcsEntity[_config.allBusiness.Count,_config.allBusiness[0].upgrades.Length];

            for(int index = 0; index < _config.allBusiness.Count; index++)
            {
                var config = _config.allBusiness[index];
                BusinessCell cell = _view.GetCell(index);
                var entity = InitBusiness(config, index,cell);
                
                for(int j = 0; j < config.upgrades.Length; j++)
                {
                   
                    var upgradeConfig = config.upgrades[j];
                    
                    var upgradeView = cell.GetUpgradeViewForIndex(j);
                    upgradeView.FillData(upgradeConfig.upgradeName,upgradeConfig.bust);
                    
                    var upgradeEntity = InitUpgrade(upgradeConfig,index, upgradeView);
                    _upgrades[index, j] = upgradeEntity;
                }


                _businessEntities[index] = entity;
               
            }
            _eventToEntity.Initialize(_businessEntities,_upgrades);
        }

        private EcsEntity InitBusiness(BusinessConfig config, int index, BusinessCell cell)
        {
            var entity = _world.NewEntity();

            ref Identificator identificator = ref entity.Get<Identificator>();
            identificator.id = index;
            
            ref IncomeProgress progress = ref entity.Get<IncomeProgress>();
            progress.current = 0;
            progress.max = config.incomeCoolDown;
           
            cell.SetNameBusines(config.businesName);
            cell.ButtonCellTaped += _eventToEntity.CellIndexButtonTap;

            ref IncomeProgressUIUpdater progressUIUpdater = ref entity.Get<IncomeProgressUIUpdater>();
            progressUIUpdater.progressView = cell;

            ref Lvl lvl = ref entity.Get<Lvl>();
            lvl.current = (index == 0) ? 1 : 0;
            lvl.basePrice = config.basePrice;
            lvl.price = _lvlCalc.PriceForLevel(lvl);

            ref LvlUpUIUpdater lvlUI = ref entity.Get<LvlUpUIUpdater>();
            lvlUI.lvlupView = cell;
            entity.Get<LvlUpgradedFlag>();
            
            if(index == 0)
            {
                entity.Get<ActiveBusinessFlag>();
            }

            ref IncomeConfig incomeConf = ref entity.Get<IncomeConfig>();
            incomeConf.baseIncome = config.baseIncome;

            ref Income income = ref entity.Get<Income>();
            
            ref IncomeUIUpdater incomeUI = ref entity.Get<IncomeUIUpdater>();
            incomeUI.incomeView = cell;
            entity.Get<IncomeUpgradedFlag>();

            ref IncomeBust bust = ref entity.Get<IncomeBust>();
            bust.bust = 0;

            return entity;
        }

        private EcsEntity InitUpgrade(BusinessUpgrade config, int businesId, IUpgradeDataView view)
        {
            var entity = _world.NewEntity();

            ref Upgrade upgrade = ref entity.Get<Upgrade>();
            upgrade.bust = config.bust / 100.0f;
            upgrade.price = config.price;
            upgrade.businessId = businesId;

            ref UpgradeUIUpdater uiUpdater = ref entity.Get<UpgradeUIUpdater>();
            uiUpdater.view = view;

            entity.Get<UpdateUpgradeUIFlag>();

            return entity;
        }
    }
}