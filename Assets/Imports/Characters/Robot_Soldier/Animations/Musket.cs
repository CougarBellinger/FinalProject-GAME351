using UnityEngine;

public class Musket : MonoBehaviour
{
    public ParticleSystem fireBurst;
    public AudioClip fireSound;

    private bool isFiring = false;
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
            StartFiring();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopFiring();
        }
    }

    void StartFiring()
    {
        if (!isFiring)
        {
            isFiring = true;
            fireBurst.Play();
            audioSource.Play();
        }
    }

    void StopFiring()
    {
        if (isFiring)
        {
            isFiring = false;
            fireBurst.Stop();
            audioSource.Stop();
        }
    }
}
