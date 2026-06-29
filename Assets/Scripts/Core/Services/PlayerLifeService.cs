using System;

public class PlayerLifeService : IDisposable
{
    private readonly EventBus _bus;
    private readonly PlayerData _player;
    private readonly IBirdCollisions _collisions;

    public PlayerLifeService(EventBus bus, IBirdCollisions collisions,  PlayerData player)
    {
        _bus = bus;
        _collisions = collisions;
        _player = player;
        
        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _collisions.PlayerDied += OnDied;
        _bus.Restarted.Invoked += OnRestart;
    }
    
    private void Unsubscribe()
    {
        _collisions.PlayerDied -= OnDied;
        _bus.Restarted.Invoked -= OnRestart;
    }

    private void OnDied()
    {
        _player.Kill();
    }
    
    private void OnRestart()
    {
        _player.Revive();
    }
}