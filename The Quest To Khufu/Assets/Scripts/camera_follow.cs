using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform Target;
    public float cameraspeed;

    public float minX,maxX;
    public float minY,maxY;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if(Target!=null)
        {
           Vector2 nexCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime*cameraspeed);
           float ClampX= Mathf.Clamp(nexCamPosition.x,minX,maxX);
           float ClampY= Mathf.Clamp(nexCamPosition.y,minY,maxY);

           transform.position=new Vector3(ClampX,ClampY,-10f);


        }

        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
