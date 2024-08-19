using UnityEngine;

public class Musket : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject fireBurstPrefab;
    public AudioClip fireSound;

    private GameObject activeFireBurst;
    private ParticleSystem fireBurstSystem;
    private AudioSource audioSource;
    private bool isFiring = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1.0f;
        audioSource.spatialBlend = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartShooting();
            if (fireSound != null)
            {
                isFiring = true;
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(fireSound); 
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
            if (isFiring)
            {
                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                isFiring = false;
            }
        }

        if (activeFireBurst != null)
        {
            activeFireBurst.transform.position = Muzzle.position;
            activeFireBurst.transform.rotation = Muzzle.rotation;
        }
    }

    void StartShooting()
    {
        if (Muzzle != null)
        {
            if (fireBurstPrefab != null)
            {
                activeFireBurst = Instantiate(fireBurstPrefab, Muzzle.position, Muzzle.rotation);
                fireBurstSystem = activeFireBurst.GetComponent<ParticleSystem>();
                if (fireBurstSystem != null)
                {
                    fireBurstSystem.Play();
                }
            }
        }
    }

    void StopShooting()
    {
        if (fireBurstSystem != null)
        {
            fireBurstSystem.Stop(true);
            Destroy(activeFireBurst);
            fireBurstSystem = null;
            activeFireBurst = null;
        }
    }
}
