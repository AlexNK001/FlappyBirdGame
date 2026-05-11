using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private UserInput _input;
    [SerializeField] private WallHandler _wallHandler;

    public override void InstallBindings()
    {
        Container.Bind<GameView>().FromInstance(_gameView).AsSingle();
        Container.Bind<UserInput>().FromInstance(_input).AsSingle();
        Container.Bind<WallHandler>().FromInstance(_wallHandler).AsSingle();
        Container.Bind<HighScoreStorage>().AsSingle();
        Container.Bind<GameState>().AsSingle();
    }
}