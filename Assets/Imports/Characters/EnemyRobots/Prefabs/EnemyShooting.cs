using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject muzzleFlashEffect;
    private EnemyAI enemyAI;

    void Start()
    {
        if (muzzleFlashEffect != null)
        {
            muzzleFlashEffect.SetActive(false);
        }

        enemyAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (enemyAI != null && muzzleFlashEffect != null)
        {
            if (IsChasingPlayer())
            {
                StartShooting();
            }
            else
            {
                StopShooting();
            }
        }
    }

    void StartShooting()
    {
        if (!muzzleFlashEffect.activeInHierarchy)
        {
            muzzleFlashEffect.SetActive(true);
        }
    }

    void StopShooting()
    {
        if (muzzleFlashEffect.activeInHierarchy)
        {
            muzzleFlashEffect.SetActive(false);
        }
    }

    bool IsChasingPlayer()
    {
        return Vector3.Distance(transform.position, enemyAI.player.transform.position) <= enemyAI.detectionRadius;
    }
}
