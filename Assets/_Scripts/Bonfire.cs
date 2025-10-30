using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Bonfire : MonoBehaviour
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
                Vector2 direction = playerKnockback.transform.position - transform.position;
                direction.Normalize();

                Vector2 targetPos = (Vector2)playerKnockback.transform.position + direction * playerKnockback.tileSize;

                RaycastHit2D hit = Physics2D.Raycast(playerKnockback.transform.position, direction, playerKnockback.tileSize, playerKnockback.obstacleMask);
                if (hit.collider != null)
                    targetPos = playerKnockback.transform.position;

                playerKnockback.StartCoroutine("KnockbackCoroutine", targetPos);
            }
        }
    }
}
