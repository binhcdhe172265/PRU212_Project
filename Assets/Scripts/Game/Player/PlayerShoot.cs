using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{


    // Update is called once per frame
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 1f;
    public float bulletForce;
    private float timeBtwFire;

    void Start()
    {
       
    }
    void Update()
    {
        timeBtwFire -= Time.deltaTime;
        if (timeBtwFire < 0)
        {
            FireBullet();
        }
    }
    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }


    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}

  
