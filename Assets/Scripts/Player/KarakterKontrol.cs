using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KarakterKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    public float hiz;
    public GameObject GroundCheck;
    public float gizmoAlani;
    public LayerMask layer;
    public float movementDirection;
    public bool yerdeMi = true;
    public bool solaBakiyorMu = true;
    public float JumpPower;
    Animator anim;

    public Image can;
    public Image mana;
    public Image xp;
    public float canAmount;
    public float manaAmount;
    public float xpAmount;
    public float xpLevel;
    public float gerekenXp;
    public Text levelSayisi;

    public GameObject shuriken;
    public Transform shurikenPoint;

    public float totalStrengt;
    public float karakterGucu = 10;
    float silahHasari;
    void Start()
    {
        xpAmount = 0;
        xpLevel = 1;
        levelSayisi.text = xpLevel.ToString();
        silahHasari = GetComponentInChildren<Weapons>().strength;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        totalStrengt = silahHasari + karakterGucu; 
        ShurikenAttack();
        can.fillAmount = canAmount / 100;
        Hizlanma();
        Ziplama();
        CheckRotation();
        ZeminKontrol();
        Attack();
    }
    public void Hizlanma()
    {
        movementDirection = Input.GetAxisRaw("Horizontal");
        if (movementDirection > 0)
        {
            anim.SetBool("1_Move", true);
        }
        else if (movementDirection < 0)
        {
            anim.SetBool("1_Move", true);
        }
        else
        {
            anim.SetBool("1_Move", false);
        }
        rb.velocity = new Vector2(movementDirection * hiz, rb.velocity.y);
    }
    void CheckRotation()
    {
        if (solaBakiyorMu == true && movementDirection > 0)
        {
            FlipFace();
        }
        else if(solaBakiyorMu == false && movementDirection < 0)
        {
            FlipFace();
        }
    }
    public void ZeminKontrol()
    {
        yerdeMi = Physics2D.OverlapCircle(GroundCheck.transform.position, gizmoAlani, layer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.transform.position, gizmoAlani);
    }
    void FlipFace()
    {
        solaBakiyorMu = !solaBakiyorMu;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            canAmount -= 20;
        }
    }
    private void XpHesap()
    {
        if (xpAmount >= gerekenXp)
        {
            xpAmount = 0;
            xpLevel += 1;
            gerekenXp += 50;
        }
    }
    public void Ziplama()
    {
        if (yerdeMi)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            }
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("2_Attack");
        }
    }
    void ShurikenAttack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject newShuriken = Instantiate(shuriken, shurikenPoint.position, Quaternion.identity);
            StartCoroutine(MoveShuriken(newShuriken));
            Destroy(newShuriken,1f);
        }
    }

    IEnumerator MoveShuriken(GameObject shurikenInstance)
    {
        float yon = 1;
        if (solaBakiyorMu == true)
        {
            yon *= -1;
        }
        else
        {
            yon = 1;
        }
        Vector2 target = new Vector2(shurikenInstance.transform.position.x + 10*yon, shurikenInstance.transform.position.y);
        while ((Vector2)shurikenInstance.transform.position != target)
        {
            shurikenInstance.transform.position = Vector2.MoveTowards(shurikenInstance.transform.position, target, Time.deltaTime * 10);
            yield return null; 
        }
    }

    //void ShurikenAttack()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        Instantiate(shuriken, shurikenPoint.position, Quaternion.identity);
    //        Vector2 target = new Vector2(shurikenPoint.position.x, shurikenPoint.position.x + 10);
    //        shuriken.transform.position = Vector2.MoveTowards(transform.position,target, Time.deltaTime);
    //    }
    //}
}
