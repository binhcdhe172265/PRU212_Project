using UnityEngine;
using UnityEngine.UI;  // Đảm bảo có thư viện UI

public class GameController : MonoBehaviour
{
    public static GameController instance; // Biến static để tham chiếu dễ dàng từ mọi nơi
    public int level = 1;  // Cấp độ hiện tại của game
    public Text levelText;  // Tham chiếu đến UI Text để hiển thị cấp độ

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Chỉ cho phép một instance của GameController tồn tại
        }
    }

    // Cập nhật cấp độ khi thay đổi
    public void UpdateLevel(int newLevel)
    {
        level = newLevel;
        levelText.text = "Level: " + level;  // Cập nhật UI Text
    }
}
