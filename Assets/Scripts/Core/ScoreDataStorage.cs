using UnityEngine;
using Zenject;

public class ScoreDataStorage
{
    private const string BestScoreKey = "BestScore";
    private readonly UnityLifecycleRelay _lifecycleRelay;
    private ScoreData _scoreData;

    public ScoreDataStorage(UnityLifecycleRelay unityLifecycleRelay)
    {
        _lifecycleRelay = unityLifecycleRelay;
    }

    public ScoreData Load()
    {
        int bestScore = PlayerPrefs.GetInt(BestScoreKey);
        _scoreData = new ScoreData(bestScore);
        _lifecycleRelay.Destroyed += OnSave;
        return _scoreData;
    }

    private void OnSave()
    {
        PlayerPrefs.SetInt(BestScoreKey, _scoreData.Best);
        PlayerPrefs.Save();
        _lifecycleRelay.Destroyed -= OnSave;
    }
}