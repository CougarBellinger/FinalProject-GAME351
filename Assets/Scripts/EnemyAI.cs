using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float wanderRadius;
    public float detectionRadius;
    public float wanderTimer;
    public GameObject gunJoint;
    public GameObject gun;
    public float rotationSpeed = 5f;

    private Transform target;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = player.transform;
        timer = wanderTimer;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer <= detectionRadius)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            if (timer <= 0)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = wanderTimer;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        RotateGunJointTowardsPlayer();
        AlignGunWithGunJoint();
    }

    void RotateGunJointTowardsPlayer()
    {
        Vector3 directionToPlayer = player.transform.position - gunJoint.transform.position;

        if (directionToPlayer!= Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            gunJoint.transform.rotation = Quaternion.Slerp(gunJoint.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void AlignGunWithGunJoint()
    {
        if (gunJoint!= null && gun!= null)
        {
            gun.transform.rotation = gunJoint.transform.rotation;
        }
    }

    static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randDirection, out hit, dist, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            return origin;
        }
    }
}