using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSound : MonoBehaviour
{
    public AudioClip fireEffect;
    public GameObject mechanicalHunter;
    
    private AudioSource audioSource;

    public float maxDistance = 100;
    float realDistance = 0;
    float distanceFactor = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireEffect;
        audioSource.loop= true;
        audioSource.Play();
        realDistance = Vector3.Distance(audioSource.transform.position, mechanicalHunter.transform.position);
        distanceFactor = 1 - (realDistance/maxDistance);
    }   

    // Update is called once per frame
    void Update()
    {
       if(distanceFactor > 0){
        audioSource.volume = distanceFactor;
       } 
       else{
        audioSource.volume = 0;
       }
    }
}
