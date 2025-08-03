using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyWalk : MonoBehaviour
{
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform target;

    [SerializeField]
    private float distance;
    private bool attackMode;
    public bool inRange;
    private bool cooling;
    private float intTimer;
    public Transform rightBound, leftBound;

    public float sagaDonus,solaDonus;

    private Animator anim;
    // public GameObject actionZone, trigerZone;
    public GameObject player;

    void Start()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
        SelectTarget();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (!attackMode)
        {
            Move();
        }
        if (inRange)
        {
            EnemyBehaviour();
        }
        if (!InsideOfBounds() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }
        Savas();
    }
    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftBound.position);
        float distanceToRight = Vector2.Distance(transform.position, rightBound.position);
        if (distanceToLeft > distanceToRight)
        {
            target = leftBound;
        }
        else
        {
            target = rightBound;
        }
        Flip();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Hasar"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = sagaDonus;
        }
        else
        {
            rotation.y = solaDonus;
        }
        transform.eulerAngles = rotation;
    }
    public void StopAttack()
    {
        attackMode = false;
        anim.SetBool("Attack", false);
        cooling = false;
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
    public void CoolDown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    public void Savas()
    {
        Vector2 a = transform.position;
        Vector2 b = player.transform.position;
        float mesafe = Vector2.Distance(a, b);
        if (mesafe < 2)
        {
            inRange = true;
            target = player.transform;
            Flip();
        }
        //else
        //{
        //    inRange = false;
        //    EnemyBehaviour();
        //}
    }
    public void EnemyBehaviour()
    {

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (distance <= attackDistance && !cooling)
        {
            Attack();
        }
        if (cooling)
        {
            anim.SetBool("Attack", false);
            CoolDown();
        }
    }
    private bool InsideOfBounds()
    {
        return transform.position.x > leftBound.position.x && transform.position.x < rightBound.position.x;
    }
    public void Move()
    {
        anim.SetBool("Walk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    public void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
    }
}
