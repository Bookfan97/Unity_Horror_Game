using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform CurrentTarget;
    [SerializeField] private Transform[] targets;
    [SerializeField] private float stopDistance = 2.0f;
    [SerializeField] private float waitTime = 2.0f;
    [SerializeField] private bool randomizePoints;
    private float distanceToTarget;
    private int targetNumber = 0;
    private Animator _animator;
    private bool Randomizer;
    private int randomNextTarget;
    private bool hasStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        CurrentTarget = targets[0];
        hasStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(CurrentTarget.position, transform.position);
        if (distanceToTarget > stopDistance)
        {
            _navMeshAgent.SetDestination(CurrentTarget.position);
            _animator.SetInteger("State", 0);
            _navMeshAgent.isStopped = false;
            if (randomizePoints)
            {
                randomNextTarget = targetNumber;
            }
        }
        if (distanceToTarget < stopDistance)
        {
            _navMeshAgent.isStopped = true;
            _animator.SetInteger("State", 1);
            StartCoroutine(LookAround());
        }
    }

    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(waitTime);
        if (hasStopped == false)
        {
            hasStopped = true;
            if (randomizePoints)
            {
                if (Randomizer)
                {
                    Randomizer = false;
                    int randomNumber = Random.Range(0, targets.Length);
                    if (targetNumber == randomNumber)
                    {
                        targetNumber++;
                        if (randomNumber >= targets.Length) 
                        { 
                            targetNumber = 0;
                        }
                    }
                    else
                    {
                        targetNumber = randomNumber;
                    }
                }
            }
            targetNumber++;
            if (targetNumber >= targets.Length)
            {
                targetNumber = 0;
            }
            SetTarget();
            yield return new WaitForSeconds(waitTime);
            hasStopped = false;
            if (randomizePoints)
            {
                Randomizer = true;
            }
        }
    }

    private void SetTarget()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (i == targetNumber)
            {
                CurrentTarget = targets[i];
            }
        }
    }
}