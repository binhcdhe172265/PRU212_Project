using UnityEngine;
using UnityEngine.UI; // Thêm thư viện UI để sử dụng Slider

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;   // Máu tối đa
    private float currentHealth;      // Máu hiện tại
    public Slider healthSlider;       // Tham chiếu đến Slider thanh máu

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;    // Đặt giá trị tối đa của thanh máu
        healthSlider.value = currentHealth;  // Đặt giá trị thanh máu ban đầu
    }

    // Hàm giảm máu
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        healthSlider.value = currentHealth; // Cập nhật thanh máu

        // Nếu máu người chơi bằng 0, tạm dừng game
        if (currentHealth == 0)
        {
            PauseGame();
        }
    }

    // Hàm hồi máu
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        healthSlider.value = currentHealth; // Cập nhật thanh máu
    }

    // Tạm dừng game khi máu người chơi bằng 0
    private void PauseGame()
    {
        Time.timeScale = 0; // Tạm dừng thời gian trong game
        Debug.Log("Game Over - Paused!");
    }
}
