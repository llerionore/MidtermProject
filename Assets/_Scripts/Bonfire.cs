using UnityEngine;

public class FireHazard : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            PlayerKnockback playerKnockback = collision.collider.GetComponent<PlayerKnockback>();

            if (playerHealth != null)
                playerHealth.TakeDamage(damage);

            if (playerKnockback != null)
            {
                // Calculate direction from fire to player (same logic as enemy contact)
                Vector2 direction = playerKnockback.transform.position - transform.position;
                direction.Normalize();

                // Simulate a 1-tile knockback (reuses PlayerKnockback logic)
                Vector2 targetPos = (Vector2)playerKnockback.transform.position + direction * playerKnockback.tileSize;

                // Check for walls like in PlayerKnockback
                RaycastHit2D hit = Physics2D.Raycast(playerKnockback.transform.position, direction, playerKnockback.tileSize, playerKnockback.obstacleMask);
                if (hit.collider != null)
                    targetPos = playerKnockback.transform.position; // blocked by wall

                // Run the same coroutine as when enemy hits player
                playerKnockback.StartCoroutine("KnockbackCoroutine", targetPos);
            }
        }
    }
}
