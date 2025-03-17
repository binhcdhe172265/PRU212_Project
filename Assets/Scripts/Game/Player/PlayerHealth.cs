using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthSlider;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        healthSlider.value = currentHealth;

        if (currentHealth == 0)
        {
            Die();
        }
    }


    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        healthSlider.value = currentHealth;
    }

    private void Die()
    {
        animator.SetBool("IsDead", true);
        animator.SetBool("IsMoving", false);
        Invoke("PauseGame", 2);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over - Paused!");
    }

}
