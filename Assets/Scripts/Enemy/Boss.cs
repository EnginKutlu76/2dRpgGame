using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator anim;
    public Rigidbody2D rb;
    public Transform player;
    private bool lookingRight = false;

    [Header("Attack")]
    public Transform attack;
    public float attackRadius;
    public LayerMask playerLayer;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        LookPlayer();
        float DistanceToPlayer = Vector2.Distance(transform.position, player.position);
        anim.SetFloat("Distance", DistanceToPlayer);
    }
    //public void Attack()
    //{
    //    Collider2D[] objects = Physics2D.OverlapCircleAll(attack.position, attackRadius,playerLayer);
    //    foreach (Collider2D collision in objects)
    //    {
    //        if (collision.CompareTag("Player"))
    //        {
    //            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
    //        }
    //    }

    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack.position, attackRadius);
    }
    public void LookPlayer()
    {
        if (player.position.x > transform.position.x && !lookingRight || player.position.x < transform.position.x && lookingRight)
        {
            FlipFace();
        }
    }
    void FlipFace()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
