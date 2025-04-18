using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private Transform target;

    public float wanderRadius;
    public float detectionRadius;

    private float wanderTimer = 1f;
    private float timer;

    public float rotationSpeed = 5f;
    public float moveSpeed = 3f;

    //audio Source variables
    private AudioSource audioSource;
    private bool hasSwitchedToFightMusic = false;
    public AudioClip defaultMusic;
    public AudioClip fightMusic;

    private NavMeshAgent navMeshAgent;
    private Vector3 selfTransform;


    void Start()
    {
        target = player.transform;
        timer = 0f;
        navMeshAgent = GetComponent<NavMeshAgent>();
        selfTransform = transform.position;
    }

    void Update()
    {
        Vector3 targetPosition = player.transform.position;

        float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);

        if (distanceToPlayer <= detectionRadius)
        {
            navMeshAgent.SetDestination(targetPosition);
            RotateTowardsPlayer();

        }
        else
        {
            if (timer <= 0)
            {
                Vector3 newPos = RandomNavSphere(selfTransform, wanderRadius);
                navMeshAgent.SetDestination(newPos);
                timer = wanderTimer;

                if ((hasSwitchedToFightMusic) && (distanceToPlayer > 10))
                {
                    audioSource.Stop();
                    audioSource.clip = defaultMusic;
                    audioSource.loop = true;
                    audioSource.Play();
                    hasSwitchedToFightMusic = false;
                }
            }

            else
            {
                timer -= Time.deltaTime;
            }
        }

        // RotateGunJointTowardsPlayer();
        // AlignGunWithGunJoint();
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = target.position - transform.position;
        directionToPlayer.y = 0;

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
    static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        return randDirection;
    }
}
