using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    public float walkRadius = 20f;

    private void Awake()
    {
        if (_agent == null)
            _agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 destination)
    {
        if (_agent == null)
        {
            Debug.LogError($"{name} tidak memiliki NavMeshAgent.");
            return;
        }
        
        _agent.SetDestination(destination);
    }
}
