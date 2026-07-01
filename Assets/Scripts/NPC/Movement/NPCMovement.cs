using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCState
{
    Idle,
    Moving
}
[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private NPCState currentState;
    public NPCState CurrentState => currentState;
    public FormationSlot CurrentSlot { get; private set; }
    private FormationSlot _targetSlot;

    private void Awake()
    {
        if (_agent == null)
        {
            _agent = GetComponent<NavMeshAgent>();
            currentState = NPCState.Idle;
        }

        
    }   

    private void Update()
    {
        RotateTowardsMovement();
        CheckArrival();
    }

    public void MoveTo(Vector3 destination)
    {
        if (_agent == null)
        {
            Debug.LogError($"{name} tidak memiliki NavMeshAgent.");
            return;
        }
        
        _agent.isStopped = false;
        _agent.SetDestination(destination);

        currentState = NPCState.Moving;
    }

    public void SetTargetSlot(FormationSlot slot)
    {
        _targetSlot = slot;
        Debug.Log($"{name} menerima target slot di posisi {slot.Position}");
        
    }

    private void CheckArrival()
    {
        if (currentState != NPCState.Moving)
            return;
        
        if (!HasReachedDestination())
            return;

        _agent.isStopped = true;
        currentState = NPCState.Idle;

        if (CurrentSlot != null)
        {
            CurrentSlot.Release();
        }
            
        if (_targetSlot != null)
        {
            Debug.Log($"{name} mempunyai target slot di posisi {_targetSlot.Position}. Menempati slot.");
            CurrentSlot = _targetSlot;
            CurrentSlot.Occupy();
            _targetSlot = null;
        }
        
        Debug.Log($"{name} telah mencapai tujuan.");
    }

    public bool HasReachedDestination()
    {
        return
        !_agent.pathPending &&
        _agent.remainingDistance <= _agent.stoppingDistance &&
        (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f);
    }

    private void RotateTowardsMovement()
    {
        if (_agent.velocity.sqrMagnitude < 0.01f)
        return;

        Quaternion targetRotation =
            Quaternion.LookRotation(_agent.velocity.normalized);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            _rotationSpeed * Time.deltaTime
        );
    }

}
