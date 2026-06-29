using System;

public class PauseService : IDisposable
{
    private readonly EventBus _bus;
    private readonly PlayerData _player;
    private readonly GameSessionData _session;
    private readonly IUserInput _input;
    private readonly IBirdCollisions _collisions;
    private readonly IStartMenuView _menu;

    public PauseService(EventBus bus, PlayerData player, GameSessionData session, IUserInput input, IBirdCollisions collisions, IStartMenuView menu)
    {
        _bus = bus;
        _player = player;
        _session = session;
        _input = input;
        _collisions = collisions;
        _menu = menu;

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _input.Paused += OnPausePressed;
        _collisions.PlayerDied += OnDied;
        _menu.StartButtonClicked += OnStartClicked;
    }
    
    private void Unsubscribe()
    {
        _input.Paused -= OnPausePressed;
        _collisions.PlayerDied -= OnDied;
        _menu.StartButtonClicked -= OnStartClicked;
    }

    private void OnStartClicked()
    {
        Toggle();
    }

    private void OnDied()
    {
       _bus.Paused.Raise();
    }

    private void OnPausePressed()
    {
        if (_player.IsAlive)
        {
            Toggle();
        }
    }
    
    private void Toggle()
    {
        if (_session.IsPlaying)
        {
            _bus.Paused.Raise();
        }
        else
        {
            _bus.Resumed.Raise();
        }
    }
}