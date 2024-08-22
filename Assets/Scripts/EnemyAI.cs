using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject muzzleFlashEffect;
    private EnemyAI enemyAI;
    private ParticleSystem muzzleParticleSystem;

    void StartFunction()
    {
        if (muzzleFlashEffect!= null)
        {
            muzzleParticleSystem = muzzleFlashEffect.GetComponent<ParticleSystem>();
            if (muzzleParticleSystem == null)
            {
                Debug.LogError("ParticleSystem component not found on muzzleFlashEffect.");
            }
            else
            {
                muzzleParticleSystem.Stop();
            }
        }
        else
        {
            Debug.LogError("muzzleFlashEffect is not assigned.");
        }

        enemyAI = GetComponent<EnemyAI>();
        if (enemyAI == null)
        {
            Debug.LogError("EnemyAI component not found.");
        }
    }

    void UpdateFunction()
    {
        if (enemyAI!= null)
        {
            if (muzzleParticleSystem!= null)
            {
                bool isChasing = IsChasingPlayer();
                if (isChasing)
                {
                    StartShooting();
                }
                else
                {
                    StopShooting();
                }
            }
        }
    }

    void StartShootingFunction()
    {
        if (muzzleParticleSystem!= null)
        {
            if (!muzzleParticleSystem.isPlaying)
            {
                Debug.Log("Starting muzzle flash effect.");
                muzzleParticleSystem.Play();
            }
        }
    }

    void StopShootingFunction()
    {
        if (muzzleParticleSystem!= null)
        {
            if (muzzleParticleSystem.isPlaying)
            {
                Debug.Log("Stopping muzzle flash effect.");
                muzzleParticleSystem.Stop();
            }
        }
    }

    bool IsChasingPlayerFunction()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, enemyAI.player.transform.position);
        return distanceToPlayer <= enemyAI.detectionRadius;
    }
}