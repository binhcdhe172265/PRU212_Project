using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Nếu sử dụng UI Slider
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;      // Máu tối đa
    private float currentHealth;        // Máu hiện tại
    public Slider healthSlider;         // Thanh máu UI
    private bool isInvulnerable = false; // Cờ kiểm tra xem người chơi có miễn nhiễm sát thương không

    void Start()
    {
        currentHealth = maxHealth;     // Khởi tạo máu hiện tại bằng máu tối đa
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // Hàm khi nhận sát thương
    public void TakeDamage(float damage)
    {
        if (isInvulnerable)  // Nếu người chơi đang miễn nhiễm sát thương
        {
            Debug.Log("Player is invulnerable, no damage taken.");
            return;  // Không nhận sát thương
        }

        currentHealth -= damage;           // Giảm máu khi nhận sát thương
        if (currentHealth < 0) currentHealth = 0;  // Đảm bảo máu không âm

        healthSlider.value = currentHealth;    // Cập nhật thanh máu

        if (currentHealth == 0)
        {
            PauseGame();     // Nếu máu bằng 0, tạm dừng game
        }
    }

    // Hàm hồi máu
    public void Heal(float amount)
    {
        currentHealth += amount;              // Thêm máu vào
        if (currentHealth > maxHealth)         // Đảm bảo máu không vượt quá tối đa
        {
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;   // Cập nhật thanh máu UI
    }

    // Kích hoạt Armor và miễn nhiễm sát thương trong thời gian nhất định
    public void ActivateArmor(float duration)
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;  // Kích hoạt miễn nhiễm sát thương
            Debug.Log("Armor Activated!");

            // Sau khoảng thời gian `duration`, hủy bỏ miễn nhiễm sát thương
            StartCoroutine(ArmorDuration(duration));
        }
    }

    private IEnumerator ArmorDuration(float duration)
    {
        yield return new WaitForSeconds(duration);  // Chờ trong khoảng thời gian `duration`
        isInvulnerable = false;  // Hủy bỏ miễn nhiễm sát thương
        Debug.Log("Armor Deactivated!");
    }

    // Hàm tạm dừng game khi máu hết
    private void PauseGame()
    {
        // Tạm dừng game (có thể bỏ phần này nếu không cần dừng thời gian)
        // Time.timeScale = 0; 

        // Chuyển sang màn hình Game Over
        SceneManager.LoadScene("GameOverScene");  // Chuyển sang scene GameOver
        Debug.Log("Game Over - Switching to GameOver Scene!");
    }
}
