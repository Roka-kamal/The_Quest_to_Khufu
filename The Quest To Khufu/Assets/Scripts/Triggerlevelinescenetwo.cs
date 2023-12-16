using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerlevelinescenetwo : MonoBehaviour
{
    public GameManager Nextscene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // Check if the triggering object is the player
        {
            Nextscene.cutscene1();
        }
    }
}

