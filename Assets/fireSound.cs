using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSound : MonoBehaviour
{
    float maxDistance = 100;
    float RealDistance = Vector3.distance (AuduioSource.transform.position, AudioListener.transform.position);
    float DistanceFactor = 1 - (RealDistance/MaxDistance);

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
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
