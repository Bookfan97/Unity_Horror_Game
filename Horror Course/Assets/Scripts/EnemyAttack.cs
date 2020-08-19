using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private NavMeshHit Hit;
    private bool blocked = false, runToPlayer = false, isChecking = true;
    private float distanceToPlayer;
    private int FailedChecks = 0;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float MaxRange = 35.0f;
    [SerializeField] private int MaxChecks = 3;
    [SerializeField] private float chaseSpeed = 8.5f;
    [SerializeField] private float walkSpeed = 1.6f;
    [SerializeField] private float AttackDistance = 2.3f;
    [SerializeField] private float attackRotateSpeed = 2.0f;
    [SerializeField] private float CheckTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);
        if (distanceToPlayer < MaxRange)
        {
            if (isChecking == true)
            {
                isChecking = false;
                //
                blocked = NavMesh.Raycast(transform.position, Player.position, out Hit, NavMesh.AllAreas);
                if (blocked == false)
                {
                    Debug.Log("I can see you, you may want to run");
                    runToPlayer = true;
                }
                if (blocked == true)
                {
                    Debug.Log("Missed it by that much");
                    runToPlayer = false;
                    _animator.SetInteger("State", 1);
                }
                StartCoroutine(TimedCheck());
            }
        }

        if (runToPlayer == true)
        {
            Enemy.GetComponent<EnemyMovement>().enabled = false;
            if (distanceToPlayer > AttackDistance)
            {
                _navMeshAgent.isStopped = false;
                _animator.SetInteger("State", 2);
                _navMeshAgent.acceleration = 24;
                _navMeshAgent.SetDestination(Player.position);
                _navMeshAgent.speed = chaseSpeed;
            }

            if (distanceToPlayer < AttackDistance)
            {
                _navMeshAgent.isStopped = true;
                Debug.Log("Finish him!");
                //_animator.SetInteger("State", 2);
                _navMeshAgent.acceleration = 180;
            }
        }
        else if (runToPlayer == false) 
        { 
            _navMeshAgent.isStopped = true; 
        }
    }

    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(CheckTime);
        isChecking = true;
    }
}
