using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _highScoreText;

    public event Action OnClickStart;

    private void Start()
    {
        _startButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnClickStart?.Invoke();
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
