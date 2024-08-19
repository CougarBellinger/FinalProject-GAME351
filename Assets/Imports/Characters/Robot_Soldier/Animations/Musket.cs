using UnityEngine;

public class Musket : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject fireParticlePrefab;
    public float fireParticleDuration = 1.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Muzzle != null)
        {
            CheckAndInstantiateFireParticle();
        }
    }

    void CheckAndInstantiateFireParticle()
    {
        if (fireParticlePrefab != null)
        {
            GameObject fireParticle = Instantiate(fireParticlePrefab, Muzzle.position, Muzzle.rotation);
            Destroy(fireParticle, fireParticleDuration);
        }
    }
}
