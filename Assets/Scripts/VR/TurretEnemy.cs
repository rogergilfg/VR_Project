using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float range = 15f;
    [SerializeField] private float fireInterval = 1.5f;
    [SerializeField] private float rotateSpeed = 4f;
    [SerializeField] private Vector3 aimOffsetEuler;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private float fireVolume = 1f;

    private Transform player;
    private float fireTimer;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 toPlayer = player.position - transform.position;
        Vector3 flat = new Vector3(toPlayer.x, 0f, toPlayer.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(flat) * Quaternion.Euler(aimOffsetEuler), rotateSpeed * Time.deltaTime);

        if (toPlayer.magnitude <= range)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f)
            {
                Instantiate(projectilePrefab, muzzle.position, Quaternion.LookRotation(player.position - muzzle.position));
                AudioManager.instance.PlaySFX(fireSound, fireVolume, false, muzzle.position);
                fireTimer = fireInterval;
            }
        }
    }
}