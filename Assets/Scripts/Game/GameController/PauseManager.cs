using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button pauseButton;
    private bool isPaused = false;

    public void TogglePauseResume()
    {
        if (isPaused)
        {
            // Resume game
            Time.timeScale = 1f;
            pauseButton.GetComponentInChildren<Text>().text = "Pause";
        }
        else
        {
            Time.timeScale = 0f; 
            pauseButton.GetComponentInChildren<Text>().text = "Resume";
        }

        isPaused = !isPaused;
    }
}
