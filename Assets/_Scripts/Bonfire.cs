using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bonfire : Enemy
{
    private Vector2 moveDirection;
    private Vector2 lastCardinalDir;

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        
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
