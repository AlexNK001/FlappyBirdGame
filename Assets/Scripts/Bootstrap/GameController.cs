using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject] private GameView _gameView;
    [Inject] private UserInput _input;
    [Inject] private WallHandler _wallHandler;
    [Inject] private GameState _gameState;
    [Inject] private HighScoreStorage _highScoreStorage;

    private void Awake()
    {
        SubscribeToGameModel();
        _gameView.Subscribe();
        SubscribeToGameView();
        _gameView.SetHighScore(_gameState.HighScore);
        SubscribeToInput();
        Pause();
    }

    private void OnDestroy()
    {
        UnsubscribeToGameState();
        UnsubscribeToGameView();
        _gameView.Unsubscribe();
        UnsubscribeToInput();
    }

    private void OnHandleDied()
    {
        _gameState.Die();
        Pause();

        if (_gameState.HighScore > _highScoreStorage.Load())
        {
            _highScoreStorage.Save(_gameState.HighScore);
        }
    }

    private void OnRestartGame()
    {
        if (_gameState.IsAlive == false)
            Restart();

        Resume();
    }

    private void OnTogglePause()
    {
        if (_gameState.IsAlive)
        {
            if (_gameState.IsPlaying)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    
    private void OnJump()
    {
        if (_gameState.IsPlaying)
            _gameView.Jump();
    }

    private void Pause()
    {
        _gameState.Pause();
        _gameView.Pause();
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        _gameState.Resume();
        _gameView.Resume();
        Time.timeScale = 1;
    }

    private void Restart()
    {
        _gameView.Restart();
        _gameState.Restart();
        _wallHandler.Restart();
    }
    
    private void SubscribeToGameModel()
    {
        _gameState.ScoreChanged += _gameView.SetScore;
        _gameState.HighScoreChanged += _gameView.SetHighScore;
    }

    private void SubscribeToGameView()
    {
        _gameView.ClickedStartButton += OnRestartGame;
        _gameView.Triggered += _gameState.AddScore;
        _gameView.Died += OnHandleDied;
    }

    private void SubscribeToInput()
    {
        _input.Jumped += OnJump;
        _input.Paused += OnTogglePause;
    }
    
    private void UnsubscribeToGameState()
    {
        _gameState.ScoreChanged -= _gameView.SetScore;
        _gameState.HighScoreChanged -= _gameView.SetHighScore;
    }

    private void UnsubscribeToGameView()
    {
        _gameView.ClickedStartButton -= OnRestartGame;
        _gameView.Triggered -= _gameState.AddScore;
        _gameView.Died -= OnHandleDied;
    }

    private void UnsubscribeToInput()
    {
        _input.Jumped -= OnJump;
        _input.Paused -= OnTogglePause;
    }
}