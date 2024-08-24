using UnityEngine;

public class Musket : MonoBehaviour
{
    public ParticleSystem fireBurst;
    public AudioClip fireSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireSound;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fireBurst.Play();
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}

