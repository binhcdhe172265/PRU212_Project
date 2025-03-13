using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;    // Prefab của enemy
    public int poolSize = 10;         // Kích thước pool, số lượng enemy tối đa trong pool
    private Queue<GameObject> enemyPool;

    void Start()
    {
        enemyPool = new Queue<GameObject>();

        // Tạo các enemy ban đầu và thêm vào pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false); // Đảm bảo enemy không hoạt động ban đầu
            enemyPool.Enqueue(enemy);
        }
    }

    // Lấy enemy từ pool
    public GameObject GetEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true); // Kích hoạt enemy
            return enemy;
        }
        else
        {
            // Nếu pool hết, tạo một enemy mới (có thể tối ưu thêm)
            GameObject enemy = Instantiate(enemyPrefab);
            return enemy;
        }
    }

    // Trả enemy về pool
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false); // Tắt enemy khi trả về pool
        enemyPool.Enqueue(enemy);
    }
}
