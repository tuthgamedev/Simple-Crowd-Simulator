using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float walkRadius = 20f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewDestination();
    }
    void Update()
    {
        if (!agent.pathPending &&
        agent.remainingDistance <= agent.stoppingDistance)
        {
            SetNewDestination();
        }
    }
    void SetNewDestination()
    {
        Vector3 randomDirection = 
            Random.insideUnitSphere * walkRadius;
        
        randomDirection += transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(
            randomDirection,
            out hit,
            walkRadius,
            NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
