using UnityEngine;

public class AmmoCollectable : MonoBehaviour
{
    public float shootingSpeedIncrease = 0.1f;  // Amount to decrease TimeBtwFire

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Check if the collectable collides with the player
        {
            // Get the player's shooting component and increase shooting speed
            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();
            if (playerShoot != null)
            {
                playerShoot.IncreaseShootingSpeed(shootingSpeedIncrease);  // Increase shooting speed
                Destroy(gameObject);  // Destroy the collectable after being picked up
            }
        }
    }
}
