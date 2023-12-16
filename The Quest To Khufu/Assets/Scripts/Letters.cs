using UnityEngine;
using TMPro;

public class Letters : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public TextMeshProUGUI letters;

    // Update is called once per frame
    void Update()
    {
        letters.text = ": " + playerhealth.lettersCollected;
    }
}
