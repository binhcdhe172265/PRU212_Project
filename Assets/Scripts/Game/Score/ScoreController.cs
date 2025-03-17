using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent<int> OnScoreChange;

    public int Score { get; private set; }

    public void AddScore(int score)
    {
        Score += score;
        OnScoreChange.Invoke(Score);
    }
}
