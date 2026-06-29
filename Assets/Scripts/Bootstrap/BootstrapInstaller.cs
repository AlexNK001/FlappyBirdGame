using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [Header("Gameplay")]
    [SerializeField] private UserInput _input;
    [SerializeField] private WallSpawner _spawner;
    [SerializeField] private WallSpawnConfig _config;

    [Header("UI")]
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private StartMenuView _startMenuView;

    [Header("Core")]
    [SerializeField] private UnityLifecycleRelay _lifecycle;

    [Header("View")]
    [SerializeField] private BirdCollisions _birdCollisions;
    [SerializeField] private BirdMovement _birdMovement;

    private ScoreDataStorage _scoreStorage;

    public override void InstallBindings()
    {
        BindCore();
        BindServices();
        BindConfigs();
    }

    private void Start() => Container.Inject(_birdMovement);

    private void BindCore()
    {
        Container.Bind<EventBus>().AsSingle();
        Container.Bind<UnityLifecycleRelay>().FromInstance(_lifecycle).AsSingle();

        _scoreStorage = new ScoreDataStorage(_lifecycle);
        Container.Bind<ScoreDataStorage>().FromInstance(_scoreStorage).AsSingle();
        ScoreData scoreData = _scoreStorage.Load();

        Container.Bind<ScoreData>().FromInstance(scoreData).AsSingle();
        Container.Bind<PlayerData>().AsSingle();
        Container.Bind<GameSessionData>().AsSingle();
    }

    private void BindServices()
    {
        Container.Bind<IUserInput>().FromInstance(_input).AsSingle();
        Container.Bind<IBirdCollisions>().FromInstance(_birdCollisions).AsSingle();
        Container.Bind<IStartMenuView>().FromInstance(_startMenuView).AsSingle();
        Container.Bind<IScoreView>().FromInstance(_scoreView).AsSingle();

        Container.Bind<InputService>().AsSingle().NonLazy();
        Container.Bind<PauseService>().AsSingle().NonLazy();
        Container.Bind<PlayerLifeService>().AsSingle().NonLazy();
        Container.Bind<RestartService>().AsSingle().NonLazy();
        Container.Bind<ScoreService>().AsSingle().NonLazy();
        Container.Bind<SessionService>().AsSingle().NonLazy();
        Container.Bind<TimeScaleService>().AsSingle().NonLazy();
        Container.Bind<UIService>().AsSingle().NonLazy();
    }

    private void BindConfigs()
    {
        Container.Bind<WallSpawnConfig>().FromInstance(_config).AsSingle();
        Container.Bind<WallRandomizer>().AsSingle();
        Container.Bind<WallSpawner>().FromInstance(_spawner).AsSingle();
    }
}