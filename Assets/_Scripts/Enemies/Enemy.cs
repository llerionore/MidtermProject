using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public abstract class Enemy : MonoBehaviour
{

    public int health = 2;
    public int damage = 1;
    public float speed = 1.5f;
    public float chaseDistance = 6f;

    public int scoreValue = 100;
    public float heartDropChance = 0.1f;

    public float knockDuration = 0.1f;
    public float tileSize = 1f;
    public LayerMask obstacleMask;

    protected Rigidbody2D rb;
    protected Animator animator;
    public GameObject deathEffect;
    public GameObject heartPrefab;
    public AudioSource audioSource;
    public AudioClip hurtClip;
    public AudioClip deathClip;
    protected Transform player;
    protected bool isKnocked = false;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void TakeDamage(int amount)
    {
        if (isKnocked) return;

        health -= amount;

        if (hurtClip != null && audioSource != null)
            audioSource.PlayOneShot(hurtClip);

        if (health <= 0)
        {
            StartCoroutine(Death());
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    protected IEnumerator FlashRed()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
        }
    }

    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    protected virtual IEnumerator Death()
    {
        if (deathClip != null && audioSource != null)
            audioSource.PlayOneShot(deathClip);

        yield return new WaitForSeconds(0.1f);
        DeathEffect();

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(100);
        }

        if (heartPrefab != null && Random.value < heartDropChance)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    public virtual IEnumerator Knockback(Vector2 sourcePos)
    {
        if (isKnocked) yield break;
        isKnocked = true;

        Vector2 dir = CardinalDirection((Vector2)transform.position - sourcePos);
        Vector2 targetPos = (Vector2)transform.position + dir * tileSize;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, tileSize, obstacleMask);
        if (hit.collider != null)
            targetPos = transform.position;

        rb.isKinematic = true;
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
        isKnocked = false;
    }

    protected Vector2 CardinalDirection(Vector2 input)
    {
        // Normalize first
        input.Normalize();

        // Strict 4-direction movement logic (no diagonal)
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            return new Vector2(Mathf.Sign(input.x), 0);
        }
        else
        {
            return new Vector2(0, Mathf.Sign(input.y));
        }
    }
}
