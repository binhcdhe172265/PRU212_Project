using UnityEngine;
using UnityEngine.SceneManagement;  // Đảm bảo bạn có thư viện SceneManager

public class SceneSwitcher : MonoBehaviour
{
    // Hàm này sẽ được gọi khi bạn muốn chuyển sang scene mới
    public void StartGame()
    {
        // Tải scene mới, thay "GameScene" bằng tên scene của bạn
        SceneManager.LoadScene("FinalProject");
    }
}
