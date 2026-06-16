using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private float clickVolume = 1f;

    private LeverSequencePuzzle puzzle;
    private Animator animator;

    void Start()
    {
        puzzle = GameObject.Find("PuzzleManager").GetComponent<LeverSequencePuzzle>();
        animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        animator.SetTrigger("Pulse");
        AudioManager.instance.PlaySFX(clickSound, clickVolume, false, transform.position);
        puzzle.OnLeverActivated(id);
    }
}
