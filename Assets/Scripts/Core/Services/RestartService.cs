using System;

public class RestartService : IDisposable
{
    private readonly EventBus _bus;
    private readonly PlayerData _player;
    private readonly IStartMenuView _menu;

    public RestartService(EventBus bus, PlayerData player, IStartMenuView menu)
    {
        _bus = bus;
        _player = player;
        _menu = menu;

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _bus.PauseToggled.Invoked += OnClicked;
        _menu.StartButtonClicked += OnClicked;
    }

    private void Unsubscribe()
    {
        _bus.PauseToggled.Invoked -= OnClicked;
        _menu.StartButtonClicked -= OnClicked;
    }

    private void OnClicked()
    {
        if (_player.IsAlive == false)
        {
            _bus.Restarted.Raise();
        }
    }
}