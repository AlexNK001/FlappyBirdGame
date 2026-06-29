using System;

public class UIService : IDisposable
{
    private readonly EventBus _bus;
    private readonly IStartMenuView _menu;
    private readonly IScoreView _scoreView;
    private readonly ScoreData _scoreData;

    public UIService(EventBus bus, ScoreData scoreData, IStartMenuView menu, IScoreView scoreView)
    {
        _bus = bus;
        _scoreData = scoreData;
        _menu = menu;
        _scoreView = scoreView;
        _scoreView.SetScore(_scoreData.Current);
        _menu.SetBestScore(_scoreData.Best);

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
        _bus.ScoreChanged.Invoked += OnHandleScoreChange;
        _menu.StartButtonClicked += OnRestarted;
    }

    private void Unsubscribe()
    {
        _bus.Paused.Invoked -= OnPause;
        _bus.Resumed.Invoked -= OnResume;
        _bus.ScoreChanged.Invoked -= OnHandleScoreChange;
        _menu.StartButtonClicked -= OnRestarted;
    }

    private void OnRestarted()
    {
        _bus.PauseToggled.Raise();
    }

    private void OnPause()
    {
        _menu.Show();
        _menu.SetBestScore(_scoreData.Best);
    }

    private void OnResume()
    {
        _menu.Hide();
    }

    private void OnHandleScoreChange(int score)
    {
        _scoreView.SetScore(score);
    }
}