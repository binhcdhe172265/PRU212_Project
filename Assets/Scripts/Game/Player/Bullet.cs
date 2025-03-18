using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20f;  // Sát thương của viên đạn

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu va chạm với enemy
        if (collision.GetComponent<EnemyHealth>())
        {
            // Lấy component EnemyHealth và gây sát thương
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);  // Gây sát thương cho enemy
            }

            // Trả bullet về pool
            BulletPool bulletPool = FindObjectOfType<BulletPool>();
            if (bulletPool != null)
            {
                bulletPool.ReturnBullet(gameObject);  // Trả bullet về pool
            }
            else
            {
                Debug.LogWarning("BulletPool not found!");
                Destroy(gameObject);  // Nếu không có BulletPool, hủy bullet
            }
        }
    }
}
