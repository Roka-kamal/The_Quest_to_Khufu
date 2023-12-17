using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_strory_dialogue : MonoBehaviour
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
                {"DID YOU KNOW Pharaohs in ancient Egypt used to burry all their belongings with them because they believed that they’ll retrieve all their belongings back in the afterlife. As a result, Pharao's tombs were full of pure gold and diamonds!! ",
                "Despite archeologists' effort to discover KHUFU'S TOMB it remains a mystery till our recent day ",
                "Abdo: HI \n I'm Abdo by the way.\n a young boy following his father's footsteps in the world of archeology looking for new adventures",
                "Abdo: And this is my friend and intern Roka.\n she will be helping me through my journey",
                "Roka: HI \n I'm really intrested to start this journey with you",
                "ARE YOU READY TO A GREAT ADVENTURE!"
            };

            dmanager.SetSentences(dialogue);
            dmanager.StartCoroutine(dmanager.TypeDialogue());
        }
    }
}
