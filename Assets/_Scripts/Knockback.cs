using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
                StartCoroutine(enemy.Knockback(transform.position));
            }
        }
    }
}
