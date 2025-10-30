using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount = 1;
    private AudioSource audioSource;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(-healAmount);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length); // wait until sound finishes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
