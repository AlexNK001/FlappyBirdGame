using UnityEngine;

public class HighScoreStorage
{
    private const string HighScoreKey = "HighScore";

    public int Load()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public void Save(int highScore)
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();
    }
}