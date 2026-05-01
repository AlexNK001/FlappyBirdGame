using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _highScoreText;

    public event UnityAction OnClickStart;

    public void Initialization()
    {
        _startButton.onClick.AddListener(OnButtonClick);
    }

    public void Destroy()
    {
        _startButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnClickStart?.Invoke();
    }

    public void ChangeHighScore(int highScore)
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