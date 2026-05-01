using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private UserInput _input;
    [SerializeField] private WallHandler _wallHandler;

    private GameState _gameModel;

    private void Awake()
    {
        Data data = new Data();
        int highScore = data.Load();
        _gameModel = new GameState(highScore);
        _gameModel.ScoreChanged += _gameView.SetScore;
        _gameModel.HighScoreChanged += _gameView.SetHighScore;
        _gameModel.Pause();

        _gameView.Initialization(_gameModel.HighScore);
        _gameView.ClickedStartButton += HandlePause;
        _gameView.Triggered += _gameModel.AddScore;
        _gameView.Died += OnHandleDied;
        _gameView.Pause();

        _input.Jumped += Jump;
        _input.Paused += HandlePause;
    }

    private void OnDestroy()
    {
        _gameModel.ScoreChanged -= _gameView.SetScore;
        _gameModel.HighScoreChanged -= _gameView.SetHighScore;

        _gameView.ClickedStartButton -= HandlePause;
        _gameView.Triggered -= _gameModel.AddScore;
        _gameView.Died -= OnHandleDied;
        _gameView.Destroy();

        _input.Jumped -= Jump;
        _input.Paused -= HandlePause;
    }

    private void HandlePause()
    {
        if (_gameModel.IsAlive == false)
        {
            Restart();
        }
        
        if (_gameModel.IsPlaying)
        {
            _gameModel.Pause();
            _gameView.Pause();
        }
        else
        {
            _gameModel.Resume();
            _gameView.Resume();
        }
    }

    private void Jump()
    {
        if (_gameModel.IsAlive)
        {
            _gameView.Jump();
        }
        else
        {
            Restart();
        }
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
        _gameModel.Pause();
    }
}