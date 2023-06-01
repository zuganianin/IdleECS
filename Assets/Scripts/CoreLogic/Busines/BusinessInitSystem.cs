using Leopotam.Ecs;
using CoreLogic.Business.Configs;

namespace CoreLogic.Business {
    sealed class BusinessInitSystem : IEcsInitSystem {
        
        readonly EcsWorld _world = null;
        readonly ConfigData _config = null;

        readonly BusinesView _view = null;

        readonly LvlPriceCalculator _lvlCalc;
        
        public void Init () {

            bool firstInited = false;
            foreach(var config in _config.allBusiness)
            {
                var entity = InitBusiness(config, !firstInited);
                if(!firstInited)
                {
                    firstInited = true;
                }
            }
        }

        public EcsEntity InitBusiness(BusinessConfig config, bool isFirst)
        {
            var entity = _world.NewEntity();
            
            ref IncomeProgress progress = ref entity.Get<IncomeProgress>();
            progress.current = 0;
            progress.max = config.incomeCoolDown;

            ref Income income = ref entity.Get<Income>();
            income.currentIncome = config.baseIncome;

            BusinessCell cell = _view.GetCell();
            cell.SetNameBusines(config.name);

            ref IncomeProgressUIUpdater progressUIUpdater = ref entity.Get<IncomeProgressUIUpdater>();
            progressUIUpdater.progressView = cell;


            ref Lvl lvl = ref entity.Get<Lvl>();
            lvl.current = isFirst ? 1 : 0;
            lvl.basePrice = config.basePrice;
            lvl.current = _lvlCalc.PriceForLevel(lvl);

            if(isFirst)
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