using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private Transform player;
    [SerializeField] private float damage;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float detectionRange;
    [SerializeField] private float runRange;
    [SerializeField] private float attackRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if(distance < attackRange)
        {
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Attack");
        }
        else if(distance < runRange)
        {
            animator.SetFloat("X", 1);
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = runSpeed;
            navMeshAgent.SetDestination(player.position);
        }
        else if(distance < detectionRange)
        {
            animator.SetFloat("X", 0.5f);
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = walkSpeed;
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            animator.SetFloat("X", 0);
            //Animacion Idle
        }


    }
}
