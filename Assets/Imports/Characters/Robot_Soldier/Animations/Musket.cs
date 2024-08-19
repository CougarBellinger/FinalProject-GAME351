using UnityEngine;

public class Musket : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject fireBurstPrefab;
    public AudioClip flameSound;

    private GameObject activeFireBurst;
    private ParticleSystem fireBurstSystem;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartShooting();
            audioSource.PlayOneShot(fireSound);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
        }

        if (activeFireBurst!= null)
        {
            activeFireBurst.transform.position = Muzzle.position;
            activeFireBurst.transform.rotation = Muzzle.rotation;
        }
    }

    void StartShooting()
    {
        if (Muzzle!= null)
        {
            if (fireBurstPrefab!= null)
            {
                activeFireBurst = Instantiate(fireBurstPrefab, Muzzle.position, Muzzle.rotation);
                fireBurstSystem = activeFireBurst.GetComponent<ParticleSystem>();
                if (fireBurstSystem!= null)
                {
                    fireBurstSystem.Play();
                }
            }
        }
    }

    void StopShooting()
    {
        if (fireBurstSystem!= null)
        {
            fireBurstSystem.Stop(true); 
            Debug.Log("Attempting to destroy burst.");
            Destroy(activeFireBurst);
            Debug.Log("Burst destroyed.");
            fireBurstSystem = null;
            activeFireBurst = null;
        }
    }
}