using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMenuView : MonoBehaviour, IStartMenuView
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _bestScoreText;

    public event Action StartButtonClicked;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        StartButtonClicked?.Invoke();
    }

    public void SetBestScore(int bestScore)
    {
        _bestScoreText.text = bestScore.ToString();
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