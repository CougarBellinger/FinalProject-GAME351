using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float wanderRadius;
    public float wanderTimer;

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

        if (distanceToPlayer <= agent.stoppingDistance)
        {
            // Player is in range, implement attack or chase behavior
            // For example:
            // agent.SetDestination(target.position);
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
    }

    static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randDirection, out hit, dist, layermask);
        return hit.position;
    }
}
