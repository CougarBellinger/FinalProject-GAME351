using UnityEngine;

public class RobotShoot : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject fireParticlePrefab;
    public GameObject laserPrefab;
    public GameObject muzzleFlashPrefab;
    public float flashDuration = 0.1f;
    public float laserDuration = 0.5f;
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
            if (muzzleFlashPrefab != null)
            {
                GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.position, Muzzle.rotation);
                Destroy(muzzleFlash, flashDuration);
            }

            if (fireParticlePrefab != null)
            {
                GameObject fireParticle = Instantiate(fireParticlePrefab, Muzzle.position, Muzzle.rotation);
                Destroy(fireParticle, fireParticleDuration);
            }

            if (laserPrefab != null)
            {
                GameObject laser = Instantiate(laserPrefab, Muzzle.position, Muzzle.rotation);
                Destroy(laser, laserDuration);
            }
        }
    }
}
