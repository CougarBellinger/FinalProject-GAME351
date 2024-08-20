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
        audioSource.loop = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!fireBurst.isPlaying)
            {
                fireBurst.Play();
            }
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
