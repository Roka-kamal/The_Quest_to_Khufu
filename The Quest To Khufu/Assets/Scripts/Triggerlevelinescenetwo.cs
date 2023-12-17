using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerlevelinescenetwo : MonoBehaviour
{
    public GameManager Nextscene;
    public PlayerHealth keys;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && keys.keysCollected >= 3) // Check if the triggering object is the player
        {
            Nextscene.cutscene1();
        }
        else
        {
            // Display message for the player when they don't have enough keys
            Debug.Log("You have to find atleast three keys to continue");
        }
    }
}

