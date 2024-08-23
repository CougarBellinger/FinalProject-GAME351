using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBullet : MonoBehaviour
{
    public float damage;
    public float lifeTime = 3f;

   private void Update()
    {
        lifeTime -= Time.deltaTime;
        
        if (lifeTime < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.GetComponent<EnemyRobot>() != null)
        {
            other.GetComponent<EnemyRobot>().health -= damage;
            //Sound effect for hurt
        }

        Destroy(gameObject);
    }
}
