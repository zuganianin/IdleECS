using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using CoreLogic.Business;
using CoreLogic.Business.Configs;
public class LoadECS : MonoBehaviour
{
    [SerializeField]
    private ConfigData _config;
    private EcsWorld _world;
    private EcsSystems _updateSystems;

    void Start()
    {
        _world = new EcsWorld();
        _updateSystems = new EcsSystems(_world);
            
        // _runtimeData = new RuntimeData();
            
        AddSystems();
        AddOneFrames();
            
        _updateSystems.
        //     Inject(configuration).
        //     Inject(sceneData).
            Inject(_config);
        
        _updateSystems.Init();

    }

    // Update is called once per frame
    void Update()
    {
        _updateSystems.Run();        
    }

    private void AddSystems()
        {
            _updateSystems.
                Add(new BusinessInitSystem()).
                Add(new IncomeProgressRunSystem()).
                Add(new IncomeTotalRunSystem())
                
                ;
        }

        private void AddOneFrames()
        {
            // _updateSystems.
            //     OneFrame<FigureFallingSpeedUpInputEvent>().
            //     OneFrame<MoveInputEvent>().
            //     OneFrame<RotateInputEvent>().
            //     OneFrame<TickEvent>().
            //     OneFrame<CheckFigureForStopRequest>().
            //     OneFrame<FigureStoppedFallingEvent>().
            //     OneFrame<InitializeCellRequest>().
            //     OneFrame<InitializeContainerRequest>().
            //     OneFrame<InitializeFigureRequest>().
            //     OneFrame<SpawnFigureRequest>().
            //     OneFrame<UpdateGameBoardViewRequest>().
            //     OneFrame<FigureEntityDestroyRequest>().
            //     OneFrame<RowsRemovedEvent>().
            //     OneFrame<FigureSpawnedEvent>().
            //     OneFrame<MouseMoveEvent>().
            //     OneFrame<ExitInputEvent>().
            //     OneFrame<SaveProgressRequest>().
            //     OneFrame<UpdateScoreViewRequest>().
            //     OneFrame<ReloadSceneRequest>().
            //     OneFrame<CloseApplicationRequest>().
            //     OneFrame<PauseInputEvent>()
            //     ;
        }
        
        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _world?.Destroy();
        }
}
