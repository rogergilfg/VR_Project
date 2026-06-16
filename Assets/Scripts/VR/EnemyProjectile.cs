using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float lifeTime = 6f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
