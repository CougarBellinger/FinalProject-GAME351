using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate1, bulletDamage;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private float timer1;

    private void Update()
    { 
        if (timer1 > 0f)
        {
            timer1 -= Time.deltaTime / fireRate1;
        }
        if (Input.GetMouseButtonDown(0) && (timer1 <= 0f))
        {
            ShootOne();
        }
    }

    void ShootOne()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<AllyBullet>().damage = bulletDamage; 

        timer1 = 1;
    }
}
