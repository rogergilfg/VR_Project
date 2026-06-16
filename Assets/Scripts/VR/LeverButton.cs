using UnityEngine;

public class LeverButton : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private float downAngle;
    [SerializeField] private float rotateSpeed = 180f;

    private LeverSequencePuzzle puzzle;
    private Quaternion restRotation;
    private Quaternion downRotation;
    private bool pulling;
    private bool locked;

    void Start()
    {
        puzzle = GameObject.Find("PuzzleManager").GetComponent<LeverSequencePuzzle>();
        restRotation = transform.localRotation;
        downRotation = restRotation * Quaternion.Euler(downAngle, 0f, 0f);
    }

    void Update()
    {
        if (!pulling || locked)
        {
            return;
        }

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, downRotation, rotateSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.localRotation, downRotation) < 1f)
        {
            transform.localRotation = downRotation;
            locked = true;
            puzzle.OnLeverActivated(id);
        }
    }

    public void Activate()
    {
        pulling = true;
    }
}
