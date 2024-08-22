using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public Transform transformPos;
    public Transform transformRot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = transformRot.rotation;
        this.transform.position = new Vector3(transformPos.position.x, this.transform.position.y, transformPos.position.z);
    }
}
