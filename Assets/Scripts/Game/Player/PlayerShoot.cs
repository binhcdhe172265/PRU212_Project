using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public float TimeBtwFire = 1f;
    public float bulletForce;
    private float timeBtwFire;
    private BulletPool bulletPool;

    void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();  // Tìm đối tượng BulletPool trong scene
    }

    void Update()
    {
        timeBtwFire -= Time.deltaTime;
        if (timeBtwFire <= 0)
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        // Lấy viên đạn từ pool
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = firePos.position;  // Đặt vị trí viên đạn
        bullet.transform.rotation = firePos.rotation;  // Đặt rotation của viên đạn

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePos.right * bulletForce, ForceMode2D.Impulse);

        // Kiểm tra nếu viên đạn ra ngoài màn hình
        StartCoroutine(CheckBulletOutOfScreen(bullet));
    }

    // Kiểm tra viên đạn ra ngoài màn hình
    IEnumerator CheckBulletOutOfScreen(GameObject bullet)
    {
        while (bullet != null && bullet.activeInHierarchy)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(bullet.transform.position);

            // Nếu viên đạn ra ngoài màn hình (nằm ngoài phạm vi 0 đến 1)
            if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            {
                bulletPool.ReturnBullet(bullet);  // Trả viên đạn về pool
                yield break;  // Dừng Coroutine
            }

            yield return null;
        }
    }

}
