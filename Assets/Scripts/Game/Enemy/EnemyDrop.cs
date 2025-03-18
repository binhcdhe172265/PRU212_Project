using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject[] itemPrefabs;  // Mảng các vật phẩm có thể rơi ra khi enemy chết
    public float dropChance = 0.5f;   // Tỉ lệ rơi vật phẩm (50% trong ví dụ này)

    // Hàm để rơi vật phẩm
    public void DropItem()
    {
        // Kiểm tra xem có rơi vật phẩm không
        if (Random.value <= dropChance)
        {
            // Chọn vật phẩm ngẫu nhiên từ mảng
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            GameObject item = itemPrefabs[randomIndex];

            // Tạo vật phẩm tại vị trí của enemy
            Instantiate(item, transform.position, Quaternion.identity);  // Vật phẩm xuất hiện tại vị trí của enemy
        }
    }
}
