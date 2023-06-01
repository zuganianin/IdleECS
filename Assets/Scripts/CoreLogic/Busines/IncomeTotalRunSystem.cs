using Leopotam.Ecs;
using UnityEngine;

namespace CoreLogic.Business {
    sealed class IncomeTotalRunSystem : IEcsRunSystem {
        
        readonly EcsWorld _world = null;
        private readonly EcsFilter<Income, IncomeProgressCompleteFlag> _filter = null;

        void IEcsRunSystem.Run () {
            if(_filter.IsEmpty())
            {
                return;
            }
            
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity (i);
                entity.Del<IncomeProgressCompleteFlag>();

                ref Income income = ref _filter.Get1(i);
                UpdateIncome(income.currentIncome);
            }
        }

        private void UpdateIncome(int count)
        {
            Debug.Log(count);
        }
    }
}