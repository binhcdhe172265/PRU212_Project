using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour
{
    public int currentGold = 0;  // Số vàng hiện tại của player
    public Text goldText;         // UI Text để hiển thị số vàng
    public GameObject safeZonePrefab;  // Prefab vùng an toàn
    private Transform playerTransform;  // Vị trí của player

    // Cài đặt giá trị cho từng vùng an toàn
    public int safeZonePrice1 = 100;
    public int safeZonePrice2 = 200;
    public int safeZonePrice3 = 300;
    public int safeZonePrice4 = 400;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateGoldText();  // Cập nhật số vàng khi game bắt đầu
    }

    // Hàm thêm vàng vào
    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldText();  // Cập nhật lại số vàng trên UI
    }

    // Hàm cập nhật số vàng lên UI
    private void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold;  // Hiển thị số vàng
        }
    }

    // Kiểm tra phím và mua vùng an toàn
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))  // Phím 1 để mua vùng an toàn size 1
        {
            if (currentGold >= safeZonePrice1)
            {
                BuySafeZone(1);
                currentGold -= safeZonePrice1;
                UpdateGoldText();  // Cập nhật lại số vàng
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))  // Phím 2 để mua vùng an toàn size 2
        {
            if (currentGold >= safeZonePrice2)
            {
                BuySafeZone(2);
                currentGold -= safeZonePrice2;
                UpdateGoldText();  // Cập nhật lại số vàng
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))  // Phím 3 để mua vùng an toàn size 3
        {
            if (currentGold >= safeZonePrice3)
            {
                BuySafeZone(3);
                currentGold -= safeZonePrice3;
                UpdateGoldText();  // Cập nhật lại số vàng
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))  // Phím 4 để mua vùng an toàn size 4
        {
            if (currentGold >= safeZonePrice4)
            {
                BuySafeZone(4);
                currentGold -= safeZonePrice4;
                UpdateGoldText();  // Cập nhật lại số vàng
            }
        }
    }

    // Hàm mua và tạo vùng an toàn
    private void BuySafeZone(int size)
    {
        // Tạo vùng an toàn tại vị trí của player
        GameObject safeZone = Instantiate(safeZonePrefab, playerTransform.position, Quaternion.identity);

        // Thay đổi scale vùng an toàn theo số tiền người chơi
        SafeZone safeZoneScript = safeZone.GetComponent<SafeZone>();
        if (safeZoneScript != null)
        {
            safeZoneScript.SetScale(size);  // Áp dụng kích thước dựa trên size
        }
    }
}
