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
        this.transform.translation(transformPos.position.forward);

        this.transform.rotation(transformPos.position.up);
        //this.transform.position.x = transformPos.position.x;
    }
}
