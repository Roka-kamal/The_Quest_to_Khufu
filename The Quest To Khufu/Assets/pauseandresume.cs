using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class pauseandresume : MonoBehaviour
{

    public GameObject PauseScreen;
    public static bool paused;
    public KeyCode Pausebutton;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        PauseScreen.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(Pausebutton)) && !paused)
        {

            pause();
        }
        else if ((Input.GetKeyDown(Pausebutton))&& paused)
        {
            resume();
        }
        void pause()
        {
            PauseScreen.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }

        void resume()
        {
            PauseScreen.SetActive(false);
            paused = false;
            Time.timeScale = 1;


        }
    }

  
}
