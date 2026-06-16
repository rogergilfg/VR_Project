using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private float moveThreshold = 0.1f;
    [SerializeField] private float volume = 1f;

    private Vector3 lastPosition;
    private bool walking;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 delta = transform.position - lastPosition;
        delta.y = 0f;
        lastPosition = transform.position;

        float speed = delta.magnitude / Time.deltaTime;
        bool movingNow = speed > moveThreshold;

        if (movingNow && !walking)
        {
            walking = true;
            AudioManager.instance.PlaySteps(volume);
        }
        else if (!movingNow && walking)
        {
            walking = false;
            AudioManager.instance.StopSteps();
        }
    }
}
