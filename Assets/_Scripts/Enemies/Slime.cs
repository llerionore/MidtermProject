using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Slime : Enemy
{
    private Vector2 moveDirection;
    private Vector2 lastCardinalDir;

    void Update()
    {
        if (player == null || isKnocked) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < chaseDistance)
        {
            // player direction
            Vector2 diff = CardinalDirection(player.position - transform.position);
            moveDirection = CardinalDirection(diff);
        }
        else
        {
            moveDirection = Vector2.zero;
        }

        AnimateMovement();
    }

    void FixedUpdate()
    {
        if (!isKnocked && moveDirection != Vector2.zero)
        {
            Vector2 nextPos = rb.position + moveDirection * speed * Time.fixedDeltaTime;

            // wall check
            RaycastHit2D hit = Physics2D.Raycast(rb.position, moveDirection, 0.5f, obstacleMask);
            if (hit.collider == null)
            {
                rb.MovePosition(nextPos);
            }
        }
    }

    private void AnimateMovement()
    {
        if (animator == null) return;

        if (moveDirection != Vector2.zero)
        {
            animator.SetBool("walking", true);
            animator.SetFloat("moveX", moveDirection.x);
            animator.SetFloat("moveY", moveDirection.y);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isKnocked && collision.collider.CompareTag("Player"))
        {
            // knockback
            PlayerKnockback playerKnock = collision.collider.GetComponent<PlayerKnockback>();
            if (playerKnock != null)
            {
                collision.collider.GetComponent<PlayerKnockback>().SendMessage("OnEnemyHit", this, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
