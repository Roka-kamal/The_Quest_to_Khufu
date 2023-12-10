using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance = null; //static to be called mn scripts tanya
    public AudioSource efxSource;
    public AudioSource musicSource;

    public float lowPitchRange=0.96f;
    public float highPitchRange = 1.05f;

    // Start is called before the first frame update
    //makan el start 7oty awake 3ashan called mara wa7da once game is played 
    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
        else if(instance!=null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip=clip;
        efxSource.Play();
    }

    public void Randomizesfx (params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange,highPitchRange);

        efxSource.pitch=randomPitch;
        efxSource.clip=clips[randomIndex];
        efxSource.Play();
    }
}
