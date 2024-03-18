using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    private int damage = 10;
    private Animator rbAnimator;
    [SerializeField] Rigidbody2D player;
    [SerializeField] AudioSource hit;
    private void Start()
    {
        rbAnimator= player.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (player.velocity.y < -5 && player.velocity.y > -7)
            {
                player.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                rbAnimator.SetBool("isHit", true);
                hit.Play();
            }
            else if (player.velocity.y < -7 && player.velocity.y > -9)
            {
                player.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * 2);
                rbAnimator.SetBool("isHit", true);
                hit.Play();
            }
            else if (player.velocity.y < -9)
            {
                player.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * 3);
            }
        }

    }
}
