using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private const string IS_MOVING = "isMoving";

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        InputController.OnInput += StartMovement;
    }

    private void StartMovement(Vector3 movement)
    {
        _navMeshAgent.SetDestination(movement);
    }

    private void Update()
    {
        _animator.SetBool(IS_MOVING, _navMeshAgent.velocity.magnitude > 0);
    }

    private void OnDestroy()
    {
        InputController.OnInput -= StartMovement;
    }
}