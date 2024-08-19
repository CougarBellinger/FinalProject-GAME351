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
        audioSource.volume = 0.5f;
        audioSource.spatialBlend = 0f;
        audioSource.loop = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartShooting();
            if (fireSound != null)
            {
                if (audioSource != null)
                {
                    isFiring = true;
                    audioSource.clip = fireSound;
                    audioSource.Play();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
            if (isFiring)
            {
                if (audioSource != null)
                {
                    if (audioSource.isPlaying)
                    {
                        audioSource.Stop();
                    }
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
