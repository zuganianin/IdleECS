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

    [SerializeField]
    private BusinesView _businessView;
    private RuntimeData _runtimeData;
    private EcsWorld _world;
    private EcsSystems _updateSystems;


    void Start()
    {
        
        _world = new EcsWorld();
        _updateSystems = new EcsSystems(_world);
        _runtimeData = new RuntimeData();
        AddSystems();
        AddOneFrames();
            
        _updateSystems.
            Inject(_runtimeData).
            Inject(_businessView).
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
                Add(new IncomeTotalRunSystem()).
                Add(new ProgressUIRunSystem()).
                Add(new MoneyRunSystem())
                ;
        }

        private void AddOneFrames()
        {
            _updateSystems.
                OneFrame<MoneyUpdateRequest>().
                OneFrame<IncomeProgressCompleteFlag>()
                ;
        }
        
        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _world?.Destroy();
        }
}
