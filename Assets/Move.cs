using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour, IAction
{

    [SerializeField] Transform target;
    [SerializeField] float maxSpeed = 6f;

    NavMeshAgent navMesh;
    ActionScheduler actionScheduler;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        actionScheduler = GetComponent<ActionScheduler>();
    }

    void Update()
    {
        //navMesh.enabled = !health.IsDead();

        UpdateAnimator();
    }

    public void StartMoveAction(Vector3 _destination)
    {
        actionScheduler.StartAction(this);
        MoveTo(_destination);
    }
    public void MoveTo(Vector3 destination)
    {
        navMesh.destination = destination;
        navMesh.isStopped = false;
    }

    public void Cancel()
    {
        navMesh.isStopped = true;
    }

    void UpdateAnimator()
    {
        Vector3 velocity = navMesh.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        //GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
