using UnityEngine;

public class fireSound : MonoBehaviour
{
    public AudioClip fireEffect;
    public GameObject tinyFire;

    private AudioSource audioSource;

    public float positionThreshold = 0.05f;

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
        if (tinyFire != null)
        {
            Vector3 positionDifference = transform.position - tinyFire.transform.position;

            if (Mathf.Abs(positionDifference.x) > positionThreshold || 
                Mathf.Abs(positionDifference.y) > positionThreshold || 
                Mathf.Abs(positionDifference.z) > positionThreshold)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }
}
