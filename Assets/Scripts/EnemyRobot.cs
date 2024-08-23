using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobot : MonoBehaviour
{
    public float health = 50f;

    private void Update ()
    {
        if(health <= 0f)
        {
            Destroy(gameObject); 
            //death sound effect ater dying
        }
    }
}
