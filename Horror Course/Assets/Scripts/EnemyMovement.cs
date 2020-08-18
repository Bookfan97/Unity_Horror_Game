using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private Transform CurrentTarget;

    //change to array
    [SerializeField] private Transform[] targets;
    //[SerializeField] private Transform target2;
    [SerializeField] private float stopDistance = 2.0f;
    private float distanceToTarget;

    private int targetNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        CurrentTarget = targets[0];
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(CurrentTarget.position, transform.position);
        if (distanceToTarget > stopDistance)
        {
            _navMeshAgent.SetDestination(CurrentTarget.position);
        }

        if (distanceToTarget < stopDistance)
        {
            targetNumber++;
            if (targetNumber >= targets.Length)
            {
                targetNumber = 1;
            }
            else
            {
                CurrentTarget  = targets[targetNumber];
            }
            //SetTarget(targetNumber);
        }
    }

    private void SetTarget(int targetNum)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (i == targetNum)
            {
                targets[i] = CurrentTarget;
            }
        }
    }
}