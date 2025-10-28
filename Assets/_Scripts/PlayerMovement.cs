using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private bool isAttacking = false;
    public float speed;
    private Vector3 change;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per framed
    void Update()
    {
        if (!isAttacking && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AttackCo());
        }
    }

    void FixedUpdate()
    {
        if (!isAttacking)
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            AnimatedMovement();
        }
    }


    private IEnumerator AttackCo() {
        Debug.Log("Attack started!");
        isAttacking = true;
        animator.SetBool("attacking", true);
        rb.velocity = Vector3.zero;

        if (audioSource != null)
        {
            audioSource.Play();
        }

        yield return new WaitForSeconds(.1f);
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.2f);
        isAttacking=false;
        Debug.Log("Attack ended!");

    }

    void AnimatedMovement() {
        if (change != Vector3.zero)
        {
            Movement();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void Movement() { 
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
