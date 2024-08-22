using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public Transform transformPos;
    public float height;

    void Update()
    {
        transform.position = transformPos.position + (Vector3.up * (height * 0.4f));
        transform.rotation = transformPos.rotation;
    }
}
