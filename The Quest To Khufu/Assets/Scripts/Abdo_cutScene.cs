using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abdo_cutScene : MonoBehaviour
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
                {"Adhamra33: We finally get to meet",
                "Abdo: I don't want to steal the tomb's treasure but people desserve to see it",
                "Adhamra33: HOW DARE YOU!",
                "Adhamra33: I've been protecting this tomb for centuries what makes you think you are stronger",
                "Abdo: I know I'm stronger and I'll win",
                "Adhamra33: LETS SEE IF YOU CAN DODGE MY BOOMARANGS"

            };

            dmanager.SetSentences(dialogue);
            dmanager.StartCoroutine(dmanager.TypeDialogue());
        }
    }
}
