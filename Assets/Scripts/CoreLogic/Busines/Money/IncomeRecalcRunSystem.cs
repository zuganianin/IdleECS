using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class IncomeRecalcRunSystem : IEcsRunSystem {
        readonly LvlPriceCalculator _calc = null;
        readonly EcsWorld _world = null;
        private readonly EcsFilter<Income, IncomeConfig, Lvl, IncomeBust, IncomeUpgradedFlag> _filter = null;

        void IEcsRunSystem.Run () {
            foreach (var i in _filter)
            {
                ref Income income = ref _filter.Get1(i);
                ref IncomeConfig incomeConf = ref _filter.Get2(i);
                ref Lvl lvl = ref _filter.Get3(i);
                ref IncomeBust bust = ref _filter.Get4(i);
                income.currentIncome = _calc.IncomeForParamets(lvl,incomeConf,bust);
            }
        }
    }
}