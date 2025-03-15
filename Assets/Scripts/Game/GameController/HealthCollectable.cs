using UnityEngine;

public class HealthCollectable : MonoBehaviour, ICollectableBeahaviour
{
    [SerializeField] private float _health;
    public void OnCollected(GameObject player)
    {
    }
}