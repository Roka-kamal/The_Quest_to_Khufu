using UnityEngine;

public class TriggerMaze : MonoBehaviour
{
    public GameManager Nextscene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // Check if the triggering object is the player
        {
            Nextscene.gotoabdoscene();
        }
    }
}