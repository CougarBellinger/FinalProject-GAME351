using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject player;
    private Transform target;
    public AudioClip defaultMusic;
    public AudioClip fightMusic;

    private AudioSource audioSource;
    private bool hasSwitchedToFightMusic = false;

    public float detectionRadius;
    

    // Start is called before the first frame update

    // Update is called once per frame
    void Update(){
        Vector3 targetPosition = player.transform.position;
        // targetPosition.y = fixedHeight;
        float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);
        if ((Input.GetMouseButton(0)) || (Input.GetKeyDown(KeyCode.F)) || (Input.GetKeyDown(KeyCode.Q)))
        {
            if (!hasSwitchedToFightMusic)
            {
                SwitchToFightMusic();
                hasSwitchedToFightMusic = true;
            }
        }
        else
        {
            if ((hasSwitchedToFightMusic) && (distanceToPlayer > 10))
            {
                SwitchToDefaultMusic();
                hasSwitchedToFightMusic = false;
            }
        }
    }
    // {
    //     //Debug.Log("Calling Update");
    //     if ((Input.GetMouseButton(0)) || (Input.GetKeyDown(KeyCode.F)) || (Input.GetKeyDown(KeyCode.Q)))
    //     {
    //         if (!hasSwitchedToFightMusic)
    //         {
    //             SwitchToFightMusic();
    //             hasSwitchedToFightMusic = true;

    //             Debug.Log("Invoked input");
    //         }
    //     }
    //     else
    //     {
    //         float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);
            
    //         if ((hasSwitchedToFightMusic) && (distanceToPlayer > detectionRadius))
    //         {
    //             SwitchToDefaultMusic();
    //             hasSwitchedToFightMusic = false;
    //         }
    //     }
    // }

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

