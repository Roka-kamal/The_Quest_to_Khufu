using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazetoAbdo : MonoBehaviour
{

    public Dialogue dmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            string[] dialogue =
                {"Skelaton: sir Abdo passed the maze and was able to get through all our snakes and bats!!",
                "Adhamra33: I told you your stupid pets aren't enough to stop him",
                "WE CAN'T LET HIM GET TO THE TOMB GO GET HIM !!!"
            };

            dmanager.SetSentences(dialogue);
            dmanager.StartCoroutine(dmanager.TypeDialogue());
        }
    }
}
