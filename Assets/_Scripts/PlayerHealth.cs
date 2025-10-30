using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int health;

    public HeartManager heartManager;
    public AudioSource audioSource;
    public AudioClip hurtClip;

    private bool isDead = false;

    void Start()
    {
        health = maxHealth;
        heartManager.UpdateHearts(health);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;
        if (health < 0) health = 0;

        heartManager.UpdateHearts(health);

        if (hurtClip != null && audioSource != null)
            audioSource.PlayOneShot(hurtClip);

        if (health <= 0)
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
