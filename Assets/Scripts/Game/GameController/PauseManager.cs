using UnityEngine;
using UnityEngine.UI; // Thêm thư viện UI để làm việc với Button

public class PauseManager : MonoBehaviour
{
    public Button pauseButton;      // Tham chiếu đến Button Pause
    private bool isPaused = false;  // Kiểm tra trạng thái game (đang Pause hay Resume)

    // Hàm để Pause hoặc Resume game
    public void TogglePauseResume()
    {
        if (isPaused)
        {
            // Resume game
            Time.timeScale = 1f; // Chạy lại game
            pauseButton.GetComponentInChildren<Text>().text = "Pause"; // Đổi chữ thành "Pause"
        }
        else
        {
            // Pause game
            Time.timeScale = 0f; // Dừng game
            pauseButton.GetComponentInChildren<Text>().text = "Resume"; // Đổi chữ thành "Resume"
        }

        isPaused = !isPaused; // Đổi trạng thái giữa Pause và Resume
    }
}
