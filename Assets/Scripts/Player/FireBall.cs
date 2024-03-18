using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, .4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("isHit", true);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
    }
}
