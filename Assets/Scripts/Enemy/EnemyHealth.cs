using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    public float maxHealth;
    private bool isDead;
    Animator anim;
    public KarakterKontrol player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            Destroy(gameObject,0.5f);
            anim.SetTrigger("Death");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hasar"))
        {
            health -= player.totalStrengt;
        }
    }

}
