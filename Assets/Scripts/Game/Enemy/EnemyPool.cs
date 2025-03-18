using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Mảng các Prefab Enemy
    public int poolSize = 10;
    private Queue<GameObject> enemyPool;

    void Awake() // Ensure enemyPool is initialized before anything else
    {
        if (enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned in EnemyPool!");
            return;
        }

        enemyPool = new Queue<GameObject>();

        // Instantiate enemies for each prefab type in the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);  // Chọn ngẫu nhiên Prefab
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    public GameObject GetEnemy()
    {
        if (enemyPool == null)
        {
            Debug.LogError("EnemyPool is not initialized!");
            return null;
        }

        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            if (enemyPrefabs.Length == 0)
            {
                Debug.LogError("No enemy prefabs available when trying to instantiate a new enemy!");
                return null;
            }

            // Nếu không còn enemy nào trong pool, tạo mới từ một Prefab ngẫu nhiên
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
            return enemy;
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        if (enemy == null)
        {
            Debug.LogError("Trying to return a null enemy!");
            return;
        }

        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
