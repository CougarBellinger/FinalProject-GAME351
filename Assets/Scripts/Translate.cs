using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public Transform transformPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = this.transform.right + transformPos.position.z + 0.1f;

        this.transform.rotation = transformPos.rotation;

        //this.transform.position.x = transformPos.position.x;
    }
}
