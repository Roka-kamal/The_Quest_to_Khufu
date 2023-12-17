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
                {
                "Abdo: WHAT IS THAT??\nRoka: WOWWW",
                "MAU: Hello friends I'm Mau one of the oldest creatures from Ancient Egypt",
                "Roka: I've always read about the magic of Ancient Egyptian cats, but I've never seen one.\ncan you help us find khufu's tomb?",
                "Mau: Your journey is very dangerous and full of evil." ,
                "Mau: Icould only help you to get your way through the maze but you'll have to continue the quest by yourself"
            };

            dmanager.SetSentences(dialogue);
            dmanager.StartCoroutine(dmanager.TypeDialogue());
        }
    }
}
