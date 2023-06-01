using Leopotam.Ecs;

namespace CoreLogic.Business  {
    sealed class MoneyRunSystem : IEcsRunSystem {
        
        readonly BusinesView _view = null;
        readonly EcsWorld _world = null;
        readonly RuntimeData _runtimeData;
        private readonly EcsFilter<MoneyUpdateRequest> _filter = null;
        
        void IEcsRunSystem.Run () {
           if(_filter.IsEmpty())
           {
                return;
           }
           _view.UpdateMoneyText(_runtimeData.Money);
        }
    }
}