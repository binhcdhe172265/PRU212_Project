using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    public void UpdateScore(int newScore)
    {
        _scoreText.text = $"Score: {newScore}";
    }
}
