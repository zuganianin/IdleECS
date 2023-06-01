using Leopotam.Ecs;

namespace CoreLogic.Business  {
    sealed class MoneyRunSystem : IEcsInitSystem, IEcsRunSystem {
        
        readonly BusinesView _view = null;
        readonly EcsWorld _world = null;
        readonly RuntimeData _runtimeData;
        private readonly EcsFilter<MoneyUpdateRequest> _filter = null;
        

        public void Init () {
            UpdateMoney();
        }
        void IEcsRunSystem.Run () {
           if(_filter.IsEmpty())
           {
                return;
           }
           UpdateMoney();
        }

        private void UpdateMoney()
        {
            _view.UpdateMoneyText(_runtimeData.Money);
        }
    }
}