using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    public GameOverManager gameOverManager;

    public void OnRestartButtonClick()
    {
        // Restart the game
        gameOverManager.RestartGame();
    }
}