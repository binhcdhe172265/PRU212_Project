using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int goldAmount;  // Số vàng mà mỗi đối tượng vàng mang lại


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (other.CompareTag("Player"))
        {
            // Tăng vàng cho player
            PlayerGold playerGold = other.GetComponent<PlayerGold>();
            if (playerGold != null)
            {
                playerGold.AddGold(goldAmount);  // Tăng số vàng cho player
            }

            // Hủy đối tượng vàng sau khi nhặt
            Destroy(gameObject);
        }
    }
}
