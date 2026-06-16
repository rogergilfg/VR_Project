using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] private Vector3 openOffset = new Vector3(0f, 3f, 0f);
    [SerializeField] private float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 targetPosition;

    void Start()
    {
        closedPosition = transform.position;
        targetPosition = closedPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, openSpeed * Time.deltaTime);
    }

    public void Open()
    {
        targetPosition = closedPosition + openOffset;
    }
}
