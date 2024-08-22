using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject muzzleFlashEffect;
    private EnemyAI enemyAI;
    private ParticleSystem muzzleParticleSystem;

    void Start()
    {
        if (muzzleFlashEffect == null)
        {
            Debug.LogError("muzzleFlashEffect is not assigned.");
            return;
        }

        muzzleParticleSystem = muzzleFlashEffect.GetComponent<ParticleSystem>();
        if (muzzleParticleSystem == null)
        {
            Debug.LogError("ParticleSystem component not found on muzzleFlashEffect.");
            return;
        }

        muzzleParticleSystem.Stop();
        enemyAI = GetComponent<EnemyAI>();
        if (enemyAI == null)
        {
            Debug.LogError("EnemyAI component not found.");
        }
    }

    void Update()
    {
        if (enemyAI == null || muzzleFlashEffect == null || muzzleParticleSystem == null)
        {
            return;
        }

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

    void StartShooting()
    {
        if (!muzzleParticleSystem.isPlaying)
        {
            Debug.Log("Starting muzzle flash effect.");
            muzzleParticleSystem.Play();
        }
    }

    void StopShooting()
    {
        if (muzzleParticleSystem.isPlaying)
        {
            Debug.Log("Stopping muzzle flash effect.");
            muzzleParticleSystem.Stop();
        }
    }

    bool IsChasingPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, enemyAI.player.transform.position);
        return distanceToPlayer <= enemyAI.detectionRadius;
    }
}
