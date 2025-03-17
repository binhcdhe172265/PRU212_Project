using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int _score;
    private ScoreController _scoreController;

    private void Awake()
    {
        _scoreController = FindAnyObjectByType<ScoreController>();
    }

    public void AllocateScore()
    {
        _scoreController.AddScore(_score);
    }
}
