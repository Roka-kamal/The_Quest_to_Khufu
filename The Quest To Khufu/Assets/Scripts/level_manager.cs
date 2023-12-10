using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_manager : MonoBehaviour
{
    public Transform enemy;
    public GameObject CurrentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawnplayer()
    {
        FindObjectOfType<player_controller>().transform.position=CurrentCheckpoint.transform.position;

    }
    // 3ashan el respwn enemy
    public void SpawnEnemy()
    {
        Instantiate(enemy,transform.position, transform.rotation);
    }
}
