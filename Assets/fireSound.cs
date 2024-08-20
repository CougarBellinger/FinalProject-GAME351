using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSound : MonoBehaviour
{
    public AudioClip fireEffect;
    public GameObject tinyFire;

    private AudioSource audioSource;

    public float maxDistance = 100;
    float realDistance = 0;
    float distanceFactor = 0;
    float stepDecrease = 10;

    void Start()
    {
        fireEffect = tinyFire.GetComponent<AudioSource>().clip;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireEffect;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        realDistance = Vector3.Distance(audioSource.transform.position, tinyFire.transform.position);
        distanceFactor = Mathf.Max(0, 100 - realDistance) / 10;
        if (distanceFactor > 0)
        {
            audioSource.volume = distanceFactor;
        }
        else
        {
            audioSource.volume = 0;
        }
    }
}