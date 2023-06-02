using Leopotam.Ecs;

namespace CoreLogic {
    sealed class DeleteRunSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private readonly EcsFilter<DeleteMark> _filter = null;
        
        void IEcsRunSystem.Run () {
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity (i);
                entity.Destroy();
            }
        }
    }
}