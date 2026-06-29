using System;

public class InputService : IDisposable
{
    private readonly EventBus _bus;
    private readonly GameSessionData _session;
    private readonly IUserInput _input;

    public InputService(EventBus bus, GameSessionData session, IUserInput input)
    {
        _bus = bus;
        _session = session;
        _input = input;
        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }
    
    private void Subscribe()
    {
        _input.Jumped += OnJump;
        _input.Paused += OnPause;
    }
    
    private void Unsubscribe()
    {
        _input.Jumped -= OnJump;
        _input.Paused -= OnPause;
    }

    private void OnPause()
    {
        _bus.PauseToggled.Raise();
    }

    private void OnJump()
    {
        if (_session.IsPlaying)
        {
            _bus.JumpRequested.Raise();
        }
    }
}