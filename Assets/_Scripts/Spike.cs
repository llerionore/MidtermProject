using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damageAmount = 1;
    public float damageCooldown = 1f;

    public AudioSource audioSource;
    public AudioClip damageClip;

    private float lastDamageTime = -999f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time >= lastDamageTime + damageCooldown)
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);

                if (audioSource != null && damageClip != null)
                    audioSource.PlayOneShot(damageClip);

                lastDamageTime = Time.time;
            }
        }
    }
}
