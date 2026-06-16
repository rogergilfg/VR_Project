using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float standoffDistance = 6f;
    [SerializeField] private float hoverHeight = 2.5f;
    [SerializeField] private float bobAmplitude = 0.3f;
    [SerializeField] private float bobSpeed = 2f;
    [SerializeField] private float fireInterval = 2f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Vector3 aimOffsetEuler;

    private Transform player;
    private float fireTimer;
    private float bobTimer;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        fireTimer = fireInterval;
    }

    void Update()
    {
        bobTimer += Time.deltaTime * bobSpeed;

        Vector3 toPlayer = player.position - transform.position;
        Vector3 flat = new Vector3(toPlayer.x, 0f, toPlayer.z).normalized;
        Vector3 desired = player.position - flat * standoffDistance;
        desired.y = player.position.y + hoverHeight + Mathf.Sin(bobTimer) * bobAmplitude;

        transform.position = Vector3.MoveTowards(transform.position, desired, moveSpeed * Time.deltaTime);

        Quaternion look = Quaternion.LookRotation(player.position - transform.position) * Quaternion.Euler(aimOffsetEuler);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, rotateSpeed * Time.deltaTime);

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            Fire();
            fireTimer = fireInterval;
        }
    }

    private void Fire()
    {
        Instantiate(projectilePrefab, muzzle.position, Quaternion.LookRotation(player.position - muzzle.position));
    }
}