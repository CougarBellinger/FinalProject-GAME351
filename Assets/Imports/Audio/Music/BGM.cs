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

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Calling Update");
        if ((Input.GetMouseButton(0)) || (Input.GetKeyDown(KeyCode.F)) || (Input.GetKeyDown(KeyCode.Q)))
        {
            if (!hasSwitchedToFightMusic)
            {
                SwitchToFightMusic();
                hasSwitchedToFightMusic = true;

                Debug.Log("Invoked input");
            }
        }
        else
        {
            //SwitchToDefaultMusic();
        }
    }

    private void SwitchToDefaultMusic()
    {
        audioSource.Stop();
        audioSource.clip = defaultMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void SwitchToFightMusic()
    {
        audioSource.Stop();
        audioSource.clip = fightMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        if (defaultMusic != null)
        {
            if (audioSource != null)
            {
            }
        }

        audioSource.clip = defaultMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

}

