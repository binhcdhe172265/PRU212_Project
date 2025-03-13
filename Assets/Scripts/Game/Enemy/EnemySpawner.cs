using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool;      // Tham chiếu đến EnemyPool
    public float spawnInterval = 3f; // Khoảng thời gian giữa các lần spawn
    public float spawnDistance = 1f; // Khoảng cách từ player đến enemy khi spawn
    public Transform player;         // Tham chiếu đến đối tượng Player

    private void Start()
    {
        // Kiểm tra xem enemyPool đã được gán chưa
        if (enemyPool == null)
        {
            Debug.LogError("Enemy Pool is not assigned in the Inspector!");
            return; // Dừng nếu không có EnemyPool
        }

        // Kiểm tra xem player có được gán chưa
        if (player == null)
        {
            Debug.LogError("Player reference is not assigned in the Inspector!");
            return; // Dừng nếu không có đối tượng Player
        }

        // Bắt đầu Coroutine để spawn enemy liên tục
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine để spawn enemy liên tục
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn enemy tại vị trí ngẫu nhiên cách player một khoảng nhất định
            SpawnEnemyAroundPlayer();

            // Chờ trong khoảng thời gian xác định trước khi spawn tiếp
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Hàm spawn enemy tại một vị trí ngẫu nhiên quanh player
    void SpawnEnemyAroundPlayer()
    {
        // Kiểm tra null để đảm bảo Camera.main tồn tại
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera is missing!");
            return; // Dừng nếu không tìm thấy Camera.main
        }

        // Lấy kích thước của màn hình trong world space
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Tính toán một điểm spawn ngẫu nhiên quanh player với khoảng cách nhất định
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // Lấy một hướng ngẫu nhiên
        Vector3 spawnPosition = (Vector2)player.position + randomDirection * spawnDistance;

        // Lấy enemy từ pool và spawn tại vị trí ngẫu nhiên quanh player
        GameObject enemy = enemyPool.GetEnemy();

        if (enemy == null)
        {
            Debug.LogError("Enemy could not be retrieved from the pool!");
            return;
        }

        // Đặt vị trí và rotation cho enemy
        enemy.transform.position = spawnPosition;

        enemy.transform.rotation = Quaternion.identity; // Đảm bảo rotation là mặc định
    }
}
