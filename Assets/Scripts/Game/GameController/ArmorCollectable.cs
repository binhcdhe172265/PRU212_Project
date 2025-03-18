using UnityEngine;

public class ArmorCollectable : MonoBehaviour
{
    public float duration = 5f;  // Thời gian miễn nhiễm sát thương sau khi nhặt (5 giây)

    // Hàm khi người chơi va chạm với vật phẩm
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Kiểm tra nếu vật phẩm va chạm với người chơi
        {
            // Lấy script PlayerHealth và kích hoạt miễn nhiễm sát thương
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.ActivateArmor(duration);  
                Destroy(gameObject); 
            }
        }
    }
}
