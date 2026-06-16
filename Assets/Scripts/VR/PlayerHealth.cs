using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float regenAmount = 10f;
    [SerializeField] private float regenInterval = 15f;

    private float currentHealth;
    private float regenTimer;
    [SerializeField] private Slider healthBar;
    private GameObject deathCanvas;

    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthBar.GetComponent<Slider>();
        healthBar.value = 1f;
        deathCanvas = GameObject.Find("DeathCanvas");
        deathCanvas.SetActive(false);
    }

    void Update()
    {
        regenTimer += Time.deltaTime;
        if (regenTimer >= regenInterval)
        {
            regenTimer = 0f;
            currentHealth = Mathf.Min(currentHealth + regenAmount, maxHealth);
            healthBar.value = currentHealth / maxHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth / maxHealth;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        deathCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}