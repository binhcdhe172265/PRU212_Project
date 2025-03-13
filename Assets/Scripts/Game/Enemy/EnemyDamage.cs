using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f; // Sát thương mà enemy gây ra mỗi lần va chạm

    // Khi enemy va chạm với người chơi (Player)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu va chạm với Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lấy PlayerHealth và giảm máu của người chơi
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);  // Gây sát thương cho người chơi
            }
        }
    }
}
