using UnityEngine;

public class EnemyGoldDrop : MonoBehaviour
{
    public int minGoldAmount = 10;  // Số vàng tối thiểu có thể rơi
    public int maxGoldAmount = 50;  // Số vàng tối đa có thể rơi
    public GameObject goldPrefab;   // Prefab vàng

    // Hàm để rơi vàng khi enemy chết
    public void DropGold()
    {
        int goldAmount = Random.Range(minGoldAmount, maxGoldAmount);  // Tính số vàng ngẫu nhiên
        Debug.Log("Gold Dropped: " + goldAmount);

        // Sinh ra một đối tượng vàng tại vị trí của enemy
        for (int i = 0; i < goldAmount; i++)
        {
            Vector3 dropPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0); // Vị trí vàng sẽ rơi xung quanh enemy
            Instantiate(goldPrefab, dropPosition, Quaternion.identity);  // Sinh ra vàng
        }
    }
}
