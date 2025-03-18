using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab của viên đạn
    public int poolSize = 10;        // Số lượng viên đạn tối đa trong pool
    private Queue<GameObject> bulletPool;

    void Start()
    {
        bulletPool = new Queue<GameObject>();

        // Tạo các viên đạn ban đầu và thêm vào pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);  // Đảm bảo viên đạn không hoạt động ban đầu
            bulletPool.Enqueue(bullet);
        }
    }

    // Lấy viên đạn từ pool
    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);  // Kích hoạt viên đạn
            return bullet;
        }
        else
        {
            // Nếu pool hết, tạo một viên đạn mới
            GameObject bullet = Instantiate(bulletPrefab);
            return bullet;
        }
    }

    // Trả viên đạn về pool
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);  // Tắt viên đạn
        bulletPool.Enqueue(bullet);  // Đưa viên đạn vào pool
    }
}
