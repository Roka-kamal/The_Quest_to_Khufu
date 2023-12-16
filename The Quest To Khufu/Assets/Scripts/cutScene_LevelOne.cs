using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutScene_LevelOne : MonoBehaviour
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
                {"Roka: Hello Abdo, ready for your adventure?",
                "Abdo: Hello Roka, yess i'm verry excied",
                "Roka: Great, let's begin"
            };

            dmanager.SetSentences(dialogue);
            dmanager.StartCoroutine(dmanager.TypeDialogue());
        }
    }
}
