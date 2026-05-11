using System;

public class GameState
{
   private int _score;

    public event Action<int> ScoreChanged;
    public event Action<int> HighScoreChanged;

    public GameState(HighScoreStorage storage)
    {
        HighScore = storage.Load();
        IsAlive = true;
    }

    public bool IsPlaying { get; private set; }
    public bool IsAlive { get; private set; }
    public int HighScore { get; private set; }

    public void Pause()
    {
        IsPlaying = false;
    }

    public void Resume()
    {
        IsPlaying = true;
    }

    public void Die()
    {
        IsAlive = false;
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);

        if (_score > HighScore)
        {
            HighScore = _score;
            HighScoreChanged?.Invoke(HighScore);
        }
    }

    public void Restart()
    {
        IsAlive = true;
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}