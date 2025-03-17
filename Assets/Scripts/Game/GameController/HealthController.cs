using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maxHealth;

    public float RemainingHealth
    {
        get
            {
            return _currentHealth/_maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth == 0)
        {
            OnDied.Invoke(); 
        }


        if (_currentHealth == 0)
        {
            _currentHealth = 0;
        }
    }

    public void AddHealth(float health)
    {
        if(_currentHealth == _maxHealth)
        {
            return;
        }

        _currentHealth += health;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public UnityEvent OnDied;
}