using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSound : MonoBehaviour
{
    public AudioClip fireSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireSound;
        audioSource.loop = true;
    }

    void Update()
    {
        //when gun trigger key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            //fireBurst.Play();
            audioSource.PlayOneShot(audioSource.clip);
            }
    }
}
