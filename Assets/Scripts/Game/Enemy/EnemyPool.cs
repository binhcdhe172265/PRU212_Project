using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    private Queue<GameObject> enemyPool;

    void Awake() // Ensure enemyPool is initialized before anything else
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("EnemyPrefab is not assigned in EnemyPool!");
            return;
        }

        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
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
            if (enemyPrefab == null)
            {
                Debug.LogError("EnemyPrefab is null when trying to instantiate a new enemy!");
                return null;
            }

            GameObject enemy = Instantiate(enemyPrefab);
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
