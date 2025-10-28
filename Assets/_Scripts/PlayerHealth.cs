using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public HeartManager heartManager;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        heartManager.UpdateHearts(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        heartManager.UpdateHearts(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Debug.Log("Game Over!");
        heartManager.GameOver();
        Time.timeScale = 0;
    }
}
