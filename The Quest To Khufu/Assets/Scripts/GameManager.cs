using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton pattern


    public void gotogameover()
    {
        SceneManager.LoadScene(2);
    }
    public void gotoadhamra33()
    {
        SceneManager.LoadScene(1);
    }
    public void gotovictoryscene()
    {
        SceneManager.LoadScene(3);
    }
    public void gotomazescene()
    {
        SceneManager.LoadScene(4);
    }
    public void gotoabdoscene()
    {
        SceneManager.LoadScene(5);
    }
    public void leveloneali()
    {
        SceneManager.LoadScene(6);
    }
    public void leveltwoali()
    {
        SceneManager.LoadScene(7);
    }
    public void cutscene1()
    {
        SceneManager.LoadScene(8);
    }
    public void abdocutscene()
    {
        SceneManager.LoadScene(9);
    }
    public void mazetoabdo()
    {
        SceneManager.LoadScene(10);
    }
    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

