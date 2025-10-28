using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Header("Knockback Settings")]
    public float tileSize = 1.0f;            // ������ ������ (��������, 1 ����)
    public float knockDuration = 0.1f;       // ������������ ������
    public LayerMask obstacleMask;           // ���� �����������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 dir = GetCardinalDirection(enemyRb.position - (Vector2)transform.position);
                Vector2 targetPos = enemyRb.position + dir * tileSize;

                // ���������, �� �������� �� ���� � �����
                RaycastHit2D hit = Physics2D.Raycast(enemyRb.position, dir, tileSize, obstacleMask);
                if (hit.collider != null)
                {
                    targetPos = enemyRb.position; // ���� ����� ������ � �� �������
                }

                StartCoroutine(TileKnockbackCoroutine(enemyRb, targetPos));
            }
        }
    }

    //����������� � ���� �� 4 ����������� (up/down/left/right)
    private Vector2 GetCardinalDirection(Vector2 input)
    {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            return new Vector2(Mathf.Sign(input.x), 0);
        else
            return new Vector2(0, Mathf.Sign(input.y));
    }

    private IEnumerator TileKnockbackCoroutine(Rigidbody2D rb, Vector2 targetPos)
    {
        rb.isKinematic = true;  // ��������� ������
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
