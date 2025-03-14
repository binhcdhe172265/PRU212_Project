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
        bulletPool = FindObjectOfType<BulletPool>();
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

        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = firePos.position;
        bullet.transform.rotation = firePos.rotation;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePos.right * bulletForce, ForceMode2D.Impulse);

        StartCoroutine(CheckBulletOutOfScreen(bullet));
    }

    IEnumerator CheckBulletOutOfScreen(GameObject bullet)
    {
        while (bullet != null && bullet.activeInHierarchy)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(bullet.transform.position);
            if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            {
                bulletPool.ReturnBullet(bullet);
                yield break;
            }

            yield return null;
        }
    }

}
