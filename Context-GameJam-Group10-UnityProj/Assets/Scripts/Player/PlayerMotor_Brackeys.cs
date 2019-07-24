using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor_Brackeys : MonoBehaviour {

    public float facingSpeed = 5f;
    private Transform target;
    NavMeshAgent NavMeshAgent;
    void Start() {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (target != null) {
            NavMeshAgent.SetDestination(target.position);
            FaceTarget();
        }
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facingSpeed);
    }

    public void MoveToPoint (Vector3 point) {
        NavMeshAgent.SetDestination(point);
    }

    public void FollowTarget (Interactable_Brackeys newTarget) {
        NavMeshAgent.stoppingDistance = newTarget.radius * .8f;
        NavMeshAgent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget () {
        NavMeshAgent.stoppingDistance = 0f;
        NavMeshAgent.updateRotation = true;
        target = null;
    }
}
