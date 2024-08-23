using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMelee : MonoBehaviour
{
    public float meleeDamage;
    public float hitRate;

    private float timer = 2;
    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime / hitRate;
        }
        if (Input.GetMouseButtonDown(0) && (timer <= 0f))
        {
            melee();
        }

    }

    private void melee()
    {
        
    }
}
