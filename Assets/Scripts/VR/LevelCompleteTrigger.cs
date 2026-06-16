using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    private bool finished;

    void Start()
    {
        winCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (finished)
        {
            return;
        }

        if (other.TryGetComponent(out PlayerHealth player))
        {
            finished = true;
            winCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
