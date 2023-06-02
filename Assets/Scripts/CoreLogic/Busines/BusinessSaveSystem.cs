using Leopotam.Ecs;
using Scripts.Services;
using UnityEngine;

namespace CoreLogic.Business {
    sealed class BusinessSaveSystem : IEcsDestroySystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly ISaver _saveService;
        readonly RuntimeData _runtimeData;

        private readonly EcsFilter<Identificator, Upgrade> _upgradeFilter = null;
        private readonly EcsFilter<Identificator, Lvl, IncomeProgress> _businessFilter = null;

        // IncomeBust
        public void Run()
        {
            Save();
        }
        public void Destroy()
        {
            Save();
        }

        private void Save()
        {
            _saveService.Save<int>(Constants.MoneyPath,_runtimeData.Money);
            
            foreach (var i in _businessFilter)
            {
                Identificator id = _businessFilter.Get1(i);
                
                Lvl lvl = _businessFilter.Get2(i);
                IncomeProgress progress = _businessFilter.Get3(i);
                
                var data = new BusinessSaveData(lvl.current,progress.current);
                _saveService.Save<BusinessSaveData>($"business_{id.id}",data);
            }

            foreach (var i in _upgradeFilter)
            {
                Identificator id = _upgradeFilter.Get1(i);
                Upgrade up = _upgradeFilter.Get2(i);
                
            }
        }
    }
}