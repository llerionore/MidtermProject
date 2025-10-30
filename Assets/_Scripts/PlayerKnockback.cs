using System.Collections;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public float tileSize = 1f;            
    public float knockDuration = 0.1f;     
    public LayerMask obstacleMask;         

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
            PlayerHealth health = GetComponent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(1);

            Vector2 direction = GetCardinalDirection(rb.position - (Vector2)collision.transform.position);
            Vector2 targetPos = rb.position + direction * tileSize;

            // wall check
            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, tileSize, obstacleMask);
            if (hit.collider != null)
                targetPos = rb.position;

            StartCoroutine(KnockbackCoroutine(targetPos));
        }
    }

    private Vector2 GetCardinalDirection(Vector2 input)
    {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            return new Vector2(Mathf.Sign(input.x), 0);
        else
            return new Vector2(0, Mathf.Sign(input.y));
    }

    public IEnumerator KnockbackCoroutine(Vector2 targetPos)
    {
        isKnocked = true;
        movement.enabled = false;

        Vector2 startPos = rb.position;
        float elapsed = 0f;

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        while (elapsed < knockDuration)
        {
            rb.MovePosition(Vector2.Lerp(startPos, targetPos, elapsed / knockDuration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPos);

        // stop
        rb.velocity = Vector2.zero;
        rb.isKinematic = false;

        yield return new WaitForSeconds(0.1f);
        movement.enabled = true;
        isKnocked = false;
    }
}
