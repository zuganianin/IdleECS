using UnityEngine;
using Leopotam.Ecs;
using CoreLogic.Business;
using CoreLogic.Business.Configs;
using Scripts.Services;

public class LoadECS : MonoBehaviour
{
    [SerializeField]
    private ConfigData _config;

    [SerializeField]
    private BusinesView _businessView;
    private RuntimeData _runtimeData;
    private EcsWorld _world;
    private EcsSystems _updateSystems;

    private LvlPriceCalculator _priceCalc;

    private SaveLoadService _saveLoad;

    void Start()
    {
        _saveLoad = new SaveLoadService();
        _world = new EcsWorld();
        _updateSystems = new EcsSystems(_world);
        _runtimeData = new RuntimeData();
        _businessView.Initialize();
        _priceCalc = new LvlPriceCalculator();

        AddSystems();
        AddOneFrames();
            
        _updateSystems.
            Inject(_saveLoad).
            Inject(_priceCalc).
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
                Add(new BusinessLoadInitSystem()).
                Add(new IncomeProgressRunSystem()).
                Add(new IncomeTotalRunSystem()).
                Add(new LvlUpgradeRunSystem()).
                Add(new UpgradeBuyRunSystem()).
                Add(new IncomeRecalcRunSystem()).
                Add(new ProgressUIRunSystem()).
                Add(new UpgradeUIRunSystem()).
                Add(new IncomeUIRunSystem()).
                Add(new LvlUpUISystem()).
                Add(new MoneyRunSystem()).
                Add(new BusinessSaveSystem())
                ;
        }

        private void AddOneFrames()
        {
            _updateSystems.
                OneFrame<TryBuyUpgradeFlag>().
                OneFrame<UpdateUpgradeUIFlag>().
                OneFrame<TryBuyLvlUpFlag>().
                OneFrame<IncomeUpgradedFlag>().
                OneFrame<LvlUpgradedFlag>().
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
