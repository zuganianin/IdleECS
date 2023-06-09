using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class IncomeUIRunSystem : IEcsRunSystem {
        private readonly EcsFilter<Income, IncomeUIUpdater, IncomeUpgradedFlag> _filter = null;
        
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