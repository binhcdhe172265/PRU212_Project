using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] maps;  // Mảng các bản đồ khác nhau
    public Transform player;      // Tham chiếu đến player
    public float spawnDistance = 10f;  // Khoảng cách khi nhân vật di chuyển đủ xa để sinh bản đồ mới
    public float destroyDistance = 15f;  // Khoảng cách khi bản đồ cũ sẽ bị hủy (hoặc đưa về pool)

    private Vector3 lastPlayerPosition;  // Lưu vị trí trước đó của player
    private List<GameObject> spawnedMaps = new List<GameObject>();  // Danh sách lưu các bản đồ đã sinh ra

    void Start()
    {
        lastPlayerPosition = player.position;  // Lưu vị trí ban đầu của player
        SpawnMap();  // Sinh bản đồ đầu tiên
    }

    void Update()
    {
        // Kiểm tra xem player có di chuyển đủ xa để sinh bản đồ mới không
        if (Vector3.Distance(player.position, lastPlayerPosition) > spawnDistance)
        {
            lastPlayerPosition = player.position;  // Cập nhật vị trí player
            SpawnMap();  // Sinh bản đồ mới
            DestroyOldMaps();  // Xóa bản đồ cũ nếu cần
        }
    }

    void SpawnMap()
    {
        // Sinh bản đồ mới tại vị trí phía trước player
        int randomMapIndex = Random.Range(0, maps.Length);  // Mảng các bản đồ khác nhau
        Vector3 spawnPosition = player.position + new Vector3(10, 0, 0);  // Sinh bản đồ phía trước player
        GameObject newMap = Instantiate(maps[randomMapIndex], spawnPosition, Quaternion.identity);

        // Thêm bản đồ mới vào danh sách
        spawnedMaps.Add(newMap);
    }

    void DestroyOldMaps()
    {
        // Duyệt qua các bản đồ đã sinh và xóa các bản đồ cũ
        for (int i = spawnedMaps.Count - 1; i >= 0; i--)
        {
            GameObject map = spawnedMaps[i];
            if (Vector3.Distance(map.transform.position, player.position) > destroyDistance)
            {
                Destroy(map);  // Xóa bản đồ nếu nó nằm quá xa player
                spawnedMaps.RemoveAt(i);  // Xóa bản đồ khỏi danh sách
            }
        }
    }
}