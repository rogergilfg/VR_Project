using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private PlayerHealth playerHealth;
    private float attackTimer;

    [SerializeField] private float damage = 12f;
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] private float detectionRange = 15f;
    [SerializeField] private float runRange = 8f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackInterval = 1.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        attackTimer -= Time.deltaTime;

        if (distance < attackRange)
        {
            navMeshAgent.isStopped = true;
            if (attackTimer <= 0f)
            {
                animator.SetTrigger("Attack");
                playerHealth.TakeDamage(damage);
                attackTimer = attackInterval;
            }
        }
        else if (distance < runRange)
        {
            animator.SetFloat("X", 1);
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = runSpeed;
            navMeshAgent.SetDestination(player.position);
        }
        else if (distance < detectionRange)
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
        }
    }
}