using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSound : MonoBehaviour
{
    public AudioClip swipeSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swipeSound;
    }

    void Update()
    {
        //when sword trigger key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

    }
}
