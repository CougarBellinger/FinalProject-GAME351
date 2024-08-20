using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip defaultMusic;
    public AudioClip fightMusic;
    
    private AudioSource audioSource;
    private bool hasSwitchedToFightMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
        if (defaultMusic != null)
        {
            audioSource = audioSource.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                defaultMusic = audioSource.clip;
            }
        }
        audioSource.clip = defaultMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if( (Input.GetMouseButton(0)) || (Input.GetKeyDown(KeyCode.F)) || (Input.GetKeyDown(KeyCode.Q)) )
        {
            if(!hasSwitchedToFightMusic)
        {
                SwitchToFightMusic();
                hasSwitchedToFightMusic = true;
            }
        }
        else{
            SwitchToDefaultMusic();
        }
    }

private void SwitchToDefaultMusic(){
    audioSource.Stop();
    audioSource.clip = defaultMusic;
    audioSource.loop = true;
    audioSource.Play();
}

 private void SwitchToFightMusic(){
    audioSource.Stop();
    audioSource.clip = fightMusic;
    audioSource.loop = true;
    audioSource.Play();
}

}