using System.Collections;
using UnityEngine;

public class AcidRain : MonoBehaviour
{
    public float damagePerSecond = 1f; // Sát thương mỗi giây
    public float rainDuration = 15f;   // Thời gian mưa axit kéo dài
    public float rainInterval = 10f;   // Thời gian nghỉ giữa các lần mưa
    public ParticleSystem rainEffect;  // Hiệu ứng mưa axit

    private PlayerHealth playerHealth;
    private Transform player; // Nhân vật chính

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform; // Tìm Player qua Tag

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
            return;
        }

        StartCoroutine(AcidRainLoop());
    }

    void LateUpdate()
    {
        if (player != null && rainEffect != null)
        {
            // Đặt vị trí của Particle System (mưa) lên trên nhân vật
            rainEffect.transform.position = player.position + new Vector3(0, 5f, 0);
        }
    }

    private IEnumerator AcidRainLoop()
    {
        yield return new WaitForSeconds(rainInterval); // Chờ 10s trước lần mưa đầu tiên

        while (true)
        {
            yield return StartCoroutine(ActivateAcidRain());
            yield return new WaitForSeconds(rainInterval); // Đợi giữa các lần mưa
        }
    }

    private IEnumerator ActivateAcidRain()
    {
        Debug.Log("Acid Rain Started!");

        float startDelay = 0f;

        // Lấy startDelay từ chính Particle System
        if (rainEffect != null)
        {
            var main = rainEffect.main;
            startDelay = main.startDelay.constant; // nếu dùng Start Delay dạng "Constant"
            rainEffect.Play();
        }

        // Chờ hiệu ứng xuất hiện rồi mới bắt đầu gây sát thương
        yield return new WaitForSeconds(startDelay);

        float elapsedTime = 0f;
        while (elapsedTime < rainDuration)
        {
            if (playerHealth != null && !IsPlayerInSafeZone() && damagePerSecond > 0)
            {
                playerHealth.TakeDamage(damagePerSecond);
            }

            elapsedTime += 1f;
            yield return new WaitForSeconds(1f);
        }

        if (rainEffect != null)
        {
            rainEffect.Stop();
        }

        Debug.Log("Acid Rain Stopped!");
    }


    private bool IsPlayerInSafeZone()
    {
        SafeZone playerSafeZone = FindObjectOfType<SafeZone>();
        if (playerSafeZone != null)
        {
            float distance = Vector3.Distance(playerSafeZone.transform.position, player.position);
            return distance <= playerSafeZone.transform.localScale.x;
        }
        return false;
    }
}
