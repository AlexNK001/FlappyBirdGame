using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}