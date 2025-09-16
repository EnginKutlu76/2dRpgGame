using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private float damage = 10f;  // Enemy attack damage
    private BoxCollider2D hitboxCollider;

    public delegate void HitPlayerEventHandler(float damage);
    public event HitPlayerEventHandler OnHitPlayer;

    private void Awake()
    {
        hitboxCollider = GetComponent<BoxCollider2D>();
        hitboxCollider.isTrigger = true;   // trigger olmalý
        hitboxCollider.enabled = false;     // baþlangýçta pasif
    }

    // Bu metodu animasyon event ile çaðýr
    public void ActivateHitBox()
    {
        hitboxCollider.enabled = true;
    }

    // Bu metodu animasyon event ile çaðýr
    public void DeactivateHitBox()
    {
        hitboxCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player script’inde TakeDamage metodu olmalý
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                OnHitPlayer?.Invoke(damage);
            }
        }
    }

}
