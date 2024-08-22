using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float wanderRadius;
    public float detectionRadius;
    public float wanderTimer;
    public GameObject gunJoint;
    public GameObject gun;
    public float rotationSpeed = 5f;
    public float moveSpeed = 3f;

    private Transform target;
    private float timer;
    private float fixedHeight = 5f;

    //audio Source variables
    private AudioSource audioSource;
    private bool hasSwitchedToFightMusic = false;
    public AudioClip defaultMusic;
    public AudioClip fightMusic;


    void Start()
    {
        target = player.transform;
        timer = wanderTimer;
    }

    void Update()
    {
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = fixedHeight;

        float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);

        if (distanceToPlayer <= detectionRadius)
        {
            MoveTowards(targetPosition);
            RotateTowardsPlayer();
        
        }
        else
        {
            if (timer <= 0)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius);
                newPos.y = fixedHeight;
                MoveTowards(newPos);
                timer = wanderTimer;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            if ((hasSwitchedToFightMusic) && (distanceToPlayer > detectionRadius))
            {
                audioSource.Stop();
                audioSource.clip = defaultMusic;
                audioSource.loop = true;
                audioSource.Play();
                hasSwitchedToFightMusic = false;
            }
        }
        

        RotateGunJointTowardsPlayer();
        AlignGunWithGunJoint();
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

    void RotateGunJointTowardsPlayer()
    {
        Vector3 directionToPlayer = target.position - gunJoint.transform.position;

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            gunJoint.transform.rotation = Quaternion.Slerp(gunJoint.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void AlignGunWithGunJoint()
    {
        if (gunJoint != null)
        {
            gun.transform.rotation = gunJoint.transform.rotation;
        }
    }

    static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        return randDirection;
    }
}
