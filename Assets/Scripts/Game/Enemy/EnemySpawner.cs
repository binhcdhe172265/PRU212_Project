using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool;      
    public float spawnInterval = 3f; 
    public float spawnDistance = 1f; 
    public Transform player;         

    private void Start()
    {
        if (enemyPool == null)
        {
            Debug.LogError("Enemy Pool is not assigned in the Inspector!");
            return; 
        }

        if (player == null)
        {
            Debug.LogError("Player reference is not assigned in the Inspector!");
            return; 
        }

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemyAroundPlayer();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyAroundPlayer()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera is missing!");
            return;
        }

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = (Vector2)player.position + randomDirection * spawnDistance;

        GameObject enemy = enemyPool.GetEnemy();

        if (enemy == null)
        {
            Debug.LogError("Enemy could not be retrieved from the pool!");
            return;
        }

        enemy.transform.position = spawnPosition;

        enemy.transform.rotation = Quaternion.identity;
    }
}
