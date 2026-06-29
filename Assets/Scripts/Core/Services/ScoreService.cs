using System;

public class ScoreService : IDisposable
{
    private readonly EventBus _bus;
    private readonly ScoreData _score;
    private readonly IBirdCollisions _collisions;

    public ScoreService(EventBus bus, ScoreData score, IBirdCollisions collisions)
    {
        _bus = bus;
        _score = score;
        _collisions = collisions;

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _bus.Restarted.Invoked += OnRestart;
        _collisions.ScoreZoneTriggered += OnScoreZone;
    }

    private void Unsubscribe()
    {
        _bus.Restarted.Invoked -= OnRestart;
        _collisions.ScoreZoneTriggered -= OnScoreZone;
    }

    private void OnScoreZone()
    {
        _score.Add();
        _bus.ScoreChanged.Raise(_score.Current);

        if (_score.TryUpdateBestScore())
        {
            _bus.BestScoreChanged.Raise(_score.Best);
        }
    }

    private void OnRestart()
    {
        _score.Reset();
    }
}