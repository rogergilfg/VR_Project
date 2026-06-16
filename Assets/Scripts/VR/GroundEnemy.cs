using UnityEngine;
using UnityEngine.AI;

public class GroundEnemy : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDamage = 12f;
    [SerializeField] private float attackInterval = 1.5f;

    private Transform player;
    private NavMeshAgent agent;
    private float attackTimer;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(player.position);

        attackTimer -= Time.deltaTime;
        if (Vector3.Distance(transform.position, player.position) <= attackRange && attackTimer <= 0f)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            attackTimer = attackInterval;
        }
    }
}
