using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_zoom : MonoBehaviour
{
    private Camera Cam;
    public float ZoomSpeed;
    public KeyCode zbutton;
    // Start is called before the first frame update
    void Start()
    {
        Cam= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(Input.GetKey(zbutton))
        {
            Cam.orthographicSize= Mathf.Lerp(Cam.orthographicSize,4, Time.deltaTime*ZoomSpeed);
        }
        //change the second parameter to the camera size
        else
        {
            Cam.orthographicSize= Mathf.Lerp(Cam.orthographicSize,5.957f, Time.deltaTime*ZoomSpeed);
        }
    }
}
