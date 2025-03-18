using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Đảm bảo đã có thư viện UI

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool;  // Tham chiếu đến Enemy Pool
    public GameObject[] enemyPrefabs;  // Mảng các Prefab Enemy để spawn
    public float spawnInterval = 3f;  // Thời gian giữa mỗi lần spawn
    public float spawnDistance = 1f;  // Khoảng cách spawn từ player
    public Transform player;  // Tham chiếu đến player

    private float timeElapsed = 0f; // Thời gian đã trôi qua
    private int currentEnemyIndex = 0; // Chỉ số enemy hiện tại (0: Enemy 1, 1: Enemy 2)

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
        GameController.instance.UpdateLevel(1);  // Cập nhật cấp độ đầu tiên khi game bắt đầu
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn enemy tùy thuộc vào thời gian (mỗi 30 giây thay đổi enemy)
            SpawnEnemyAroundPlayer();

            // Tăng thời gian đã trôi qua
            timeElapsed += spawnInterval;

            // Sau mỗi 15 giây, tăng độ khó và giảm thời gian giữa các lần spawn
            if (timeElapsed >= 15f)
            {
                timeElapsed = 0f; // Reset thời gian
                IncreaseDifficulty();  // Tăng độ khó
            }

            yield return new WaitForSeconds(spawnInterval);  // Chờ trước khi spawn tiếp
        }
    }

    void IncreaseDifficulty()
    {
        GameController.instance.level++;  // Tăng cấp độ trong GameController

        // Giảm thời gian spawn (tăng tốc độ spawn)
        spawnInterval = Mathf.Max(0.5f, spawnInterval - 0.5f);  // Giảm thời gian spawn tối thiểu là 0.5s

        // Cập nhật Text hiển thị cấp độ
        GameController.instance.UpdateLevel(GameController.instance.level);  // Cập nhật cấp độ mới

        // Đổi enemy theo cấp độ (nếu muốn)
        currentEnemyIndex = GameController.instance.level % enemyPrefabs.Length;  // Chuyển qua enemy tiếp theo
        Debug.Log("Level: " + GameController.instance.level + ", Spawn Interval: " + spawnInterval);
    }

    void SpawnEnemyAroundPlayer()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera is missing!");
            return;
        }

        // Lấy kích thước màn hình trong world space
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Tạo một vị trí ngẫu nhiên quanh player
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = (Vector2)player.position + randomDirection * spawnDistance;

        // Chọn enemy từ mảng Prefabs dựa trên chỉ số `currentEnemyIndex`
        GameObject selectedEnemyPrefab = enemyPrefabs[currentEnemyIndex];

        // Lấy enemy từ pool
        GameObject enemy = enemyPool.GetEnemy();

        if (enemy == null)
        {
            Debug.LogError("Enemy could not be retrieved from the pool!");
            return;
        }

        // Spawn enemy tại vị trí ngẫu nhiên
        enemy.transform.position = spawnPosition;
        enemy.transform.localScale = selectedEnemyPrefab.transform.localScale; // Đảm bảo kích thước của enemy đúng

        // Gán Prefab cho enemy
        enemy.GetComponent<SpriteRenderer>().sprite = selectedEnemyPrefab.GetComponent<SpriteRenderer>().sprite;

        enemy.transform.rotation = Quaternion.identity;  // Đặt lại góc quay của enemy
    }
}
