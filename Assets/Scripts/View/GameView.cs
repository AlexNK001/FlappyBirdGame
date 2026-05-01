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

    public void Initialization(int highScore)
    {
        SetHighScore(highScore);
        _birdView.Initialization();
        _menu.Initialization();
        _birdView.Triggered += OnHandleTriggered;
        _birdView.Died += OnHandleDied;
        _menu.OnClickStart += OnHandleClick;
    }

    public void Destroy()
    {
        _birdView.Triggered -= OnHandleTriggered;
        _birdView.Died -= OnHandleDied;
        _menu.OnClickStart -= OnHandleClick;
        _menu.Destroy();
    }

    private void OnHandleTriggered()
    {
        Triggered.Invoke();
    }

    private void OnHandleDied()
    {
        Died.Invoke();
        Pause();
    }

    private void OnHandleClick()
    {
        ClickedStartButton.Invoke();
        Restart();
        Resume();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _menu.Show();
    }

    public void Resume()
    {
        Time.timeScale = 1;
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
        _menu.ChangeHighScore(highScore);
    }

    public void Restart()
    {
        _birdView.Restart();
    }
}