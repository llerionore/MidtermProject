using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public float tileSize = 1f;            // длина "клетки" (1 юнит = 1 клетка)
    public float knockDuration = 0.1f;     // длительность отлета
    public LayerMask obstacleMask;         // слой преп€тствий

    private Rigidbody2D rb;
    private PlayerMovement movement;
    private bool isKnocked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isKnocked && collision.collider.CompareTag("Enemy"))
        {
            Vector2 direction = GetCardinalDirection(rb.position - (Vector2)collision.transform.position);
            Vector2 targetPos = rb.position + direction * tileSize;

            // ѕроверка на стену
            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, tileSize, obstacleMask);
            if (hit.collider != null)
            {
                targetPos = rb.position; // если р€дом стена, не двигаемс€
            }

            StartCoroutine(KnockbackCoroutine(targetPos));
        }
    }

    private Vector2 GetCardinalDirection(Vector2 input)
    {
        // ¬ыбор строго 4 направлений (без диагоналей)
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            return new Vector2(Mathf.Sign(input.x), 0);
        else
            return new Vector2(0, Mathf.Sign(input.y));
    }

    private IEnumerator KnockbackCoroutine(Vector2 targetPos)
    {
        isKnocked = true;
        movement.enabled = false; // выключаем управление игроком

        Vector2 startPos = rb.position;
        float elapsed = 0f;

        while (elapsed < knockDuration)
        {
            rb.MovePosition(Vector2.Lerp(startPos, targetPos, elapsed / knockDuration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPos);

        yield return new WaitForSeconds(0.1f);
        movement.enabled = true;
        isKnocked = false;
    }
}

