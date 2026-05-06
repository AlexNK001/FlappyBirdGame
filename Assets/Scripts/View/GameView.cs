using UnityEngine;
using UnityEngine.Events;

public class GameView : MonoBehaviour
{
    [SerializeField] private BirdView _birdView;
    [SerializeField] private Menu _menu;
    [SerializeField] private ScoreDisplay _scoreDisplay;
    
    public event UnityAction Triggered;
    public event UnityAction Died;
    public event UnityAction ClickedStartButton;

    public void Subscribe()
    {
        _menu.Subscribe();
        _birdView.Triggered += OnHandleTriggered;
        _birdView.Died += OnHandleDied;
        _menu.StartButtonClicked += OnHandleClick;
    }

    public void Unsubscribe()
    {
        _birdView.Triggered -= OnHandleTriggered;
        _birdView.Died -= OnHandleDied;
        _menu.StartButtonClicked -= OnHandleClick;
        _menu.Unsubscribe();
    }

    private void OnHandleTriggered()
    {
        Triggered?.Invoke();
    }

    private void OnHandleDied()
    {
        Died?.Invoke();
    }

    private void OnHandleClick()
    {
        ClickedStartButton?.Invoke();
    }

    public void Pause()
    {
        _menu.Show();
    }

    public void Resume()
    {
        _menu.Hide();
    }

    public void Jump()
    {
        _birdView.Jump();
    }
    
    public void SetScore(int score)
    {
        _scoreDisplay.SetScore(score);
    }

    public void SetHighScore(int highScore)
    {
        _menu.SetHighScore(highScore);
    }

    public void Restart()
    {
        _birdView.Restart();
    }
}