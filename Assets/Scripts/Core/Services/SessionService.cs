using System;

public class SessionService : IDisposable
{
    private readonly EventBus _bus;
    private readonly GameSessionData _session;
    private readonly IStartMenuView _menu;

    public SessionService(EventBus bus, GameSessionData session, IStartMenuView menu)
    {
        _bus = bus;
        _session = session;
        _menu = menu;

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _menu.StartButtonClicked += OnResume;
        _bus.Paused.Invoked += OnPause;
        _bus.Resumed.Invoked += OnResume;
    }

    private void Unsubscribe()
    {
        _menu.StartButtonClicked -= OnResume;
        _bus.Paused.Invoked -= OnPause;
        _bus.Resumed.Invoked -= OnResume;
    }

    private void OnPause()
    {
        _session.Pause();
    }

    private void OnResume()
    {
        _session.Resume();
    }
}