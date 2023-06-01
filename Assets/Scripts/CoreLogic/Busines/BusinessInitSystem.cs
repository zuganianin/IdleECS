using Leopotam.Ecs;
using CoreLogic.Business.Configs;

namespace CoreLogic.Business {
    sealed class BusinessInitSystem : IEcsInitSystem {
        
        readonly EcsWorld _world = null;
        readonly ConfigData _config = null;

        readonly BusinesView _view = null;

        readonly LvlPriceCalculator _lvlCalc;

        private EcsEntity[] _entities;

        private UiEventToEntity _eventToEntity;
        
        public void Init () {
            _eventToEntity = new UiEventToEntity();
            int index = 0;
            _entities = new EcsEntity[_config.allBusiness.Count];

            foreach(var config in _config.allBusiness)
            {
                var entity = InitBusiness(config, index);
                _entities[index] = entity;
                index++;
            }
            _eventToEntity.Initialize(_entities);
        }

        public EcsEntity InitBusiness(BusinessConfig config, int index)
        {
            var entity = _world.NewEntity();
            
            ref IncomeProgress progress = ref entity.Get<IncomeProgress>();
            progress.current = 0;
            progress.max = config.incomeCoolDown;

            ref Income income = ref entity.Get<Income>();
            income.currentIncome = config.baseIncome;

            BusinessCell cell = _view.GetCell(index);
            cell.SetNameBusines(config.name);
            cell.ButtonCellTaped += _eventToEntity.CellIndexButtonTap;

            ref IncomeProgressUIUpdater progressUIUpdater = ref entity.Get<IncomeProgressUIUpdater>();
            progressUIUpdater.progressView = cell;


            ref Lvl lvl = ref entity.Get<Lvl>();
            lvl.current = (index == 0) ? 1 : 0;
            lvl.basePrice = config.basePrice;
            lvl.price = _lvlCalc.PriceForLevel(lvl);

            ref LvlUpUIUpdater lvlUI = ref entity.Get<LvlUpUIUpdater>();
            lvlUI.lvlupView = cell;
            entity.Get<LvlUpdateUIFlag>();
            
            if(index == 0)
            {
                entity.Get<ActiveBusinessFlag>();
            }

            ref IncomeUIUpdater incomeUI = ref entity.Get<IncomeUIUpdater>();
            incomeUI.incomeView = cell;
            entity.Get<IncomeUpdateRequest>();
            return entity;
        }
    }
}