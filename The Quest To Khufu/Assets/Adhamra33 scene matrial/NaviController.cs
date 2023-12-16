using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NaviController : MonoBehaviour
{

    public void gotointroscene()
    {
        SceneManager.LoadScene(0);
    }

    public void gotoadhamra33()
    {
        SceneManager.LoadScene(1);
    }

    public void gotogameover()
    {
        SceneManager.LoadScene(2);
    }

    public void gotovictoryscene()
    {
        SceneManager.LoadScene(3);
    }
    public void gotomazescene ()
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

    //    public void quit()
    //    {
    //#if UNITY_EDITOR
    //        UnityEditor.EditorApplication.isPlaying = false;
    //#else
    //        Application.Quit();
    //#endif
    //    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
