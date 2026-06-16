using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 15f;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float lifeTime = 5f;

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
        if (other.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
