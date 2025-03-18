using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;    // Máu tối đa của enemy
    private float currentHealth;       // Máu hiện tại của enemy
    private EnemyDrop enemyDrop;       // Tham chiếu đến EnemyDrop
    private EnemyGoldDrop enemyGoldDrop;
    void Start()
    {
        currentHealth = maxHealth;    // Khởi tạo máu hiện tại
        enemyDrop = GetComponent<EnemyDrop>(); // Lấy tham chiếu đến script EnemyDrop
        enemyGoldDrop = GetComponent<EnemyGoldDrop>();
    }

    // Hàm nhận sát thương
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // Giảm máu khi nhận sát thương
        if (currentHealth <= 0)
        {
            Die();  // Nếu máu <= 0 thì enemy chết
        }
    }

    // Hàm khi enemy chết
    private void Die()
    {
        // Gọi EnemyDrop để rơi vật phẩm
        if (enemyDrop != null)
        {
            enemyDrop.DropItem();   // Rơi vật phẩm
        }

        if (enemyGoldDrop != null)
        {
            enemyGoldDrop.DropGold();
        }


        // Trả enemy về pool và tắt nó
        EnemyPool enemyPool = FindObjectOfType<EnemyPool>();
        if (enemyPool != null)
        {
            enemyPool.ReturnEnemy(gameObject);  // Trả enemy về pool
        }
        else
        {
            Debug.LogWarning("EnemyPool not found!");
        }

        gameObject.SetActive(false); // Hủy enemy khỏi scene (hoặc trả lại pool nếu dùng pooling)
    }
}
