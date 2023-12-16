using UnityEngine;
using TMPro;

public class Keys : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public TextMeshProUGUI keys;

    // Update is called once per frame
    void Update()
    {
        keys.text = ": " + playerhealth.keysCollected;
    }
}
