using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth playerHealth; 
    public float fireDamage = 20f;
    private AudioSource audioSource;
    public AudioClip playerSound;
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            Debug.Log("Player touched fire!");
            if (playerSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(playerSound);
            }
            playerHealth.TakeDamage(fireDamage);
        }
    }
}
