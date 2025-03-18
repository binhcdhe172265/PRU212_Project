using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    public float healthAmount = 25f;  // Lượng máu hồi khi nhặt vật phẩm

    // Hàm khi người chơi va chạm với vật phẩm
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Kiểm tra xem vật phẩm có va chạm với người chơi không
        {
            // Lấy component PlayerHealth và hồi máu
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healthAmount); // Hồi máu cho người chơi
                Destroy(gameObject);  // Hủy vật phẩm sau khi nhặt
            }
        }
    }
}
