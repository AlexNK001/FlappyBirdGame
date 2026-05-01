using UnityEngine;

public class Data
{
    private const string Highscore = "HighScore";

    public int Load()
    {
        return PlayerPrefs.GetInt(Highscore, 0);
    }

    public void Save(int highScore)
    {
        PlayerPrefs.SetInt(Highscore, highScore);
        PlayerPrefs.Save();
    }
}