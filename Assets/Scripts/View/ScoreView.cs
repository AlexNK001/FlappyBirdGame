using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour, IScoreView
{
    [SerializeField] private TMP_Text _scoreText;
    private EventBus _bus;
    
    [Inject]
    private void Construct(EventBus bus)
    {
        _bus = bus;
        _bus.Restarted.Invoked += OnRestart;
    }

    private void OnRestart()
    {
        _scoreText.text = "0";
    }

    private void OnDestroy()
    {
        _bus.Restarted.Invoked -= OnRestart;
    }

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}