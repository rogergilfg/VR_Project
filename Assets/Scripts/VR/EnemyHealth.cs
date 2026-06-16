using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private float deathDelay = 2f;

    private float currentHealth;
    private bool dead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (dead)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        dead = true;

        if (TryGetComponent(out EnemyController controller))
        {
            controller.enabled = false;
        }

        if (TryGetComponent(out NavMeshAgent agent))
        {
            agent.isStopped = true;
        }

        if (TryGetComponent(out Animator animator))
        {
            animator.SetTrigger("Dead");
            Destroy(gameObject, deathDelay);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
