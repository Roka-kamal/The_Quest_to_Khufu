using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    void Start()
    {
        HideGameOverScreen();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void HideGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGameScene"); // Replace "MainGameScene" with the actual name of your main game scene.
    }
}
