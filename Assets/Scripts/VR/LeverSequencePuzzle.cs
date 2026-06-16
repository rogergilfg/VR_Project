using UnityEngine;

public class LeverSequencePuzzle : MonoBehaviour
{
    [SerializeField] private int[] correctSequence = { 0, 2, 1 };

    private PuzzleDoor door;
    private int progress;

    void Start()
    {
        door = GameObject.Find("PuzzleDoor").GetComponent<PuzzleDoor>();
    }

    public void OnLeverActivated(int id)
    {
        Debug.Log("Boton pulsado: " + id + " | esperaba: " + correctSequence[progress]);

        if (id == correctSequence[progress])
        {
            progress++;
            Debug.Log("Correcto. Progreso: " + progress + "/" + correctSequence.Length);
            if (progress >= correctSequence.Length)
            {
                Debug.Log("Secuencia completa, abriendo puerta");
                door.Open();
                progress = 0;
            }
        }
        else
        {
            Debug.Log("Fallo, secuencia reiniciada");
            progress = 0;
        }
    }
}
