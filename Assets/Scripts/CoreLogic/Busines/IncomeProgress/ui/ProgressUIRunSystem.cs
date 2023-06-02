using Leopotam.Ecs;

namespace CoreLogic.Business {
    sealed class ProgressUIRunSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        private readonly EcsFilter<IncomeProgressUIUpdater,IncomeProgress> _filter = null;

        void IEcsRunSystem.Run () {
           foreach (var i in _filter)
            {
                ref IncomeProgressUIUpdater ui = ref _filter.Get1(i);
                ref IncomeProgress progress = ref _filter.Get2(i);
                ui.progressView.SetProgress(progress.procent);
            }
        }
    }
}