using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class IncomeUIRunSystem : IEcsRunSystem {
        
        readonly EcsWorld _world = null;
        private readonly EcsFilter<Income, IncomeUIUpdater, IncomeUpdateRequest> _filter = null;
        
        void IEcsRunSystem.Run () {
            if(_filter.IsEmpty())
            {
                return;
            }
            foreach(var i in _filter)
            {
                ref Income income = ref _filter.Get1(i);
                ref IncomeUIUpdater incomeUI = ref _filter.Get2(i);
                incomeUI.incomeView.SetIncomeValue(income.currentIncome);
            }
        }
    }
}