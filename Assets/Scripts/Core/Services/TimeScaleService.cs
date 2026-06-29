using System;
using UnityEngine;

public class TimeScaleService : IDisposable
{
    private readonly EventBus _bus;
    private readonly UnityLifecycleRelay _lifecycle;

    public TimeScaleService(EventBus bus, UnityLifecycleRelay lifecycle)
    {
        _bus = bus;
        _lifecycle = lifecycle;

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _bus.Paused.Invoked += OnPause;
        _bus.Resumed.Invoked += OnResume;
        _lifecycle.Started += OnStartGame;
    }

    private void Unsubscribe()
    {
        _bus.Paused.Invoked -= OnPause;
        _bus.Resumed.Invoked -= OnResume;
        _lifecycle.Started -= OnStartGame;
    }

    private void OnPause()
    {
        Time.timeScale = 0f;
    }

    private void OnResume()
    {
        Time.timeScale = 1f;
    }
    
    private void OnStartGame()
    {
        OnPause();
        _lifecycle.Started -= OnStartGame;
    }
}