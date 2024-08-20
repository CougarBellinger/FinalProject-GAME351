using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSound : MonoBehaviour
{
    float maxDistance = 100;
    float RealDistance = 0;
    float DistanceFactor = o;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
        realDistance = Vector3.distance(AudioSource.transform.position, AudioListener.transform.position);
        DistanceFactor = 1 - (RealDistanc/MaxDistance);
    }   

    // Update is called once per frame
    void Update()
    {
       if(DistanceFactor > 0){
        AudioSource.volume = DistanceFactor;
       } 
       else{
        AudioSource.volume = 0;
       }
    }
}
