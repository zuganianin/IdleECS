using Leopotam.Ecs;
using UnityEngine;

namespace CoreLogic.Business {
    sealed class IncomeProgressRunSystem : IEcsRunSystem {
        
        readonly EcsWorld _world = null;
        private readonly EcsFilter<IncomeProgress> _filter = null;
        
        void IEcsRunSystem.Run () {
            foreach (var i in _filter)
            {
                ref IncomeProgress progress = ref _filter.Get1(i);
                if (ProgressWasCompleted(ref progress))
                {
                    ref EcsEntity entity = ref _filter.GetEntity (i);
                    entity.Get<IncomeProgressCompleteFlag>();
                }
            }
        }

        private bool ProgressWasCompleted(ref IncomeProgress progress)
        {
            bool result = false;
            progress.current += Time.deltaTime;
            
            if(progress.current >= progress.max)
            {
                //TODO: can make one frame completed?
                progress.current = 0.0f;
                result = true;
            }
            progress.procent =  progress.current / progress.max;
            return result;
        }
    }
}