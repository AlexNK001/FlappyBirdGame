using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _highScoreText;

    public event UnityAction StartButtonClicked;

    public void Subscribe()
    {
        _startButton.onClick.AddListener(OnButtonClick);
    }

    public void Unsubscribe()
    {
        _startButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        StartButtonClicked?.Invoke();
    }

    public void SetHighScore(int highScore)
    {
        _highScoreText.text = highScore.ToString();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}