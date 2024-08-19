using UnityEngine;

public class Musket : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject fireBurstPrefab;
    public AudioClip fireSound; // 声明火焰声音的音频剪辑

    private GameObject activeFireBurst;
    private ParticleSystem fireBurstSystem;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("Assets/Audio/FireSound"); // 请将"Assets/Audio/FireSound"替换为您实际的音频文件路径
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