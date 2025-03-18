using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text levelText;   // Text UI để hiển thị level
    public Button restartButton;  // Nút Restart
    public Button exitButton;     // Nút Exit

    void Start()
    {
        // Hiển thị level đạt được khi game over
        levelText.text = "Level: " + GameController.instance.level.ToString();  // Giả sử level được lưu trong GameController

        // Cài đặt sự kiện cho các nút
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Hàm restart game
    void RestartGame()
    {
        // Chuyển lại về scene chơi game (tên scene có thể thay đổi tùy bạn)
        SceneManager.LoadScene("FinalProject");
    }

    // Hàm thoát game (hoặc quay lại màn hình start)
    void ExitGame()
    {
        // Quay lại màn hình chính (hoặc menu)
        SceneManager.LoadScene("StrartScene");
    }
}
