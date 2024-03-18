using UnityEngine;

public class ShootingArrow : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] private float damage;
    private Animator anim;
    [SerializeField] int direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * direction * speed;
        Destroy(this.gameObject, .4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("isHit", true);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
