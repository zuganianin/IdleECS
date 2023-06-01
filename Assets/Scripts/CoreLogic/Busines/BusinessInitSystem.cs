using Leopotam.Ecs;
using CoreLogic.Business.Configs;

namespace CoreLogic.Business {
    sealed class BusinessInitSystem : IEcsInitSystem {
        
        readonly EcsWorld _world = null;
        readonly ConfigData _config = null;
        
        public void Init () {
            foreach(var config in _config.allBusiness)
            {
                InitBusiness(config);
            }
        }

        public void InitBusiness(BusinessConfig config)
        {
            var entity = _world.NewEntity();
            
            ref IncomeProgress progress = ref entity.Get<IncomeProgress>();
            progress.current = 0;
            progress.max = config.incomeCoolDown;

            ref Income income = ref entity.Get<Income>();
            income.currentIncome = config.baseIncome;
        }
    }
}