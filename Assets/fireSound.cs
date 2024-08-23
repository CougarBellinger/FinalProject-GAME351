using UnityEngine;

public class fireSound : MonoBehaviour
{
    public AudioClip fireEffect;
    public GameObject tinyFire;

    private AudioSource audioSource;
    void Start()
    {
        if (tinyFire != null)
        {
            AudioSource tinyFireAudio = tinyFire.GetComponent<AudioSource>();
            if (tinyFireAudio != null)
            {
                fireEffect = tinyFireAudio.clip;
            }
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireEffect;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        
            }
 }

