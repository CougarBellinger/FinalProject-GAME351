using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public Transform transformPos;

    void Start()
    {

    }

    void Update()
    {
        transform.position = transformPos.position;
        transform.rotation = Quaternion.LookRotation(transformPos.forward, transformPos.up);
    }
}
