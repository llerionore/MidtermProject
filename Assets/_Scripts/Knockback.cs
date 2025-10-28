using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Header("Knockback Settings")]
    public float tileSize = 1.0f;            // размер клетки (например, 1 юнит)
    public float knockDuration = 0.1f;       // длительность отлета
    public LayerMask obstacleMask;           // слой преп€тствий

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 dir = GetCardinalDirection(enemyRb.position - (Vector2)transform.position);
                Vector2 targetPos = enemyRb.position + dir * tileSize;

                // ѕровер€ем, не ударитс€ ли враг в стену
                RaycastHit2D hit = Physics2D.Raycast(enemyRb.position, dir, tileSize, obstacleMask);
                if (hit.collider != null)
                {
                    targetPos = enemyRb.position; // если стена близко Ч не двигаем
                }

                StartCoroutine(TileKnockbackCoroutine(enemyRb, targetPos));
            }
        }
    }

    //ѕреобразуем в одно из 4 направлений (up/down/left/right)
    private Vector2 GetCardinalDirection(Vector2 input)
    {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            return new Vector2(Mathf.Sign(input.x), 0);
        else
            return new Vector2(0, Mathf.Sign(input.y));
    }

    private IEnumerator TileKnockbackCoroutine(Rigidbody2D rb, Vector2 targetPos)
    {
        rb.isKinematic = true;  // отключаем физику
        Vector2 startPos = rb.position;
        float elapsed = 0f;

        while (elapsed < knockDuration)
        {
            rb.MovePosition(Vector2.Lerp(startPos, targetPos, elapsed / knockDuration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPos);
        rb.isKinematic = false;
    }
}
