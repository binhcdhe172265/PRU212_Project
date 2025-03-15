using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 Directionplayer { get; private set; }
    [SerializeField]
    private float _playerAwareDistance;
    [SerializeField]
    private Transform _player; 
    private void Aware()
    {
        _player = FindAnyObjectByType<PlayerMovement>().transform;
    }
    void Start()
    {
        Aware();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        Directionplayer = enemyToPlayerVector.normalized;
        if (enemyToPlayerVector.magnitude <= _playerAwareDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
