using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Collect : MonoBehaviour
{
    public int key_value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
          //  FindObjectOfType<player_controller>().totalkey += key_value;
            Destroy(this.gameObject);
        }
    }
}