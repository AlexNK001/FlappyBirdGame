using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private UserInput _input;
    [SerializeField] private WallHandler _wallHandler;

    private GameState _gameModel;
    private HighScoreStorage _highScoreStorage;

    private void Awake()
    {
        _highScoreStorage = new HighScoreStorage();
        int highScore = _highScoreStorage.Load();

        _gameModel = new GameState(highScore);
        _gameModel.ScoreChanged += _gameView.SetScore;
        _gameModel.HighScoreChanged += _gameView.SetHighScore;

        _gameView.Subscribe();
        _gameView.ClickedStartButton += OnRestartGame;
        _gameView.Triggered += _gameModel.AddScore;
        _gameView.Died += OnHandleDied;
        _gameView.SetHighScore(_gameModel.HighScore);

        _input.Jumped += OnJump;
        _input.Paused += OnTogglePause;

        Pause();
    }

    private void OnDestroy()
    {
        _gameModel.ScoreChanged -= _gameView.SetScore;
        _gameModel.HighScoreChanged -= _gameView.SetHighScore;

        _gameView.ClickedStartButton -= OnRestartGame;
        _gameView.Triggered -= _gameModel.AddScore;
        _gameView.Died -= OnHandleDied;
        _gameView.Unsubscribe();

        _input.Jumped -= OnJump;
        _input.Paused -= OnTogglePause;
    }

    private void OnRestartGame()
    {
        if (_gameModel.IsAlive == false)
            Restart();

        Resume();
    }

    private void OnTogglePause()
    {
        if (_gameModel.IsAlive)
        {
            if (_gameModel.IsPlaying)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        _gameModel.Pause();
        _gameView.Pause();
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        _gameModel.Resume();
        _gameView.Resume();
        Time.timeScale = 1;
    }

    private void OnJump()
    {
        if (_gameModel.IsPlaying)
            _gameView.Jump();
    }

    private void Restart()
    {
        _gameView.Restart();
        _gameModel.Restart();
        _wallHandler.Restart();
    }

    private void OnHandleDied()
    {
        _gameModel.Die();
        Pause();

        int highScore = _highScoreStorage.Load();

        if (highScore > _gameModel.HighScore)
        {
            _highScoreStorage.Save(highScore);
        }
    }
}