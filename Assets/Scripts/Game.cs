using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const string Highscore = "HighScore";

    [SerializeField] private Bird _bird;
    [SerializeField] private Menu _menu;
    [SerializeField] private WallHandler _wallHandler;
    [SerializeField] private WallPool wallPool;
    [SerializeField] private TMP_Text _scoreText;

    private KeyCode _jumpKey = KeyCode.Space;
    private int _currentScore;
    private int _highScore;
    private bool _isPlaying;

    private void Awake()
    {
        int highScore = PlayerPrefs.GetInt(Highscore, 0);
        _menu.SetHighScore(highScore);

        Pause();

        _bird.Collided += OnEndGame;
        _bird.Triggered += OnAddScore;
        _menu.OnClickStart += OnRestart;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey) && _isPlaying)
        {
            _bird.Jump();
        }

        if (Input.GetKeyDown(_jumpKey) && _isPlaying == false)
        {
            OnRestart();
        }
    }

    private void OnDestroy()
    {
        _bird.Collided -= OnEndGame;
        _bird.Triggered -= OnAddScore;
        _menu.OnClickStart -= Unpause;
    }

    private void OnEndGame()
    {
        if (TrySaveScore(out int newHighScore))
            _menu.SetHighScore(newHighScore);

        Pause();
    }

    private void OnAddScore()
    {
        _currentScore++;
        _scoreText.text = ConvertScore(_currentScore);
    }

    private bool TrySaveScore(out int newHighScore)
    {
        newHighScore = PlayerPrefs.GetInt(Highscore, 0);
        bool becameBigger = _currentScore > newHighScore;

        if (becameBigger)
        {
            PlayerPrefs.SetInt(Highscore, _currentScore);
            PlayerPrefs.Save();
        }

        return becameBigger;
    }

    private void OnRestart()
    {
        _wallHandler.Restart();
        _bird.Restart();

        Unpause();

        _currentScore = 0;
        _scoreText.text = ConvertScore(_currentScore);
    }

    private void Pause()
    {
        _isPlaying = false;
        Time.timeScale = 0f;
        _menu.Show();
    }

    private void Unpause()
    {
        _isPlaying = true;
        Time.timeScale = 1;
        _menu.Hide();
    }

    private string ConvertScore(int score)
    {
        return $"Score: {score}";
    }
}