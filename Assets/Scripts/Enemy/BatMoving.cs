using UnityEngine;

public class BatMoving : MonoBehaviour
{
    [SerializeField] private float rayRange;
    public GameObject point1, point2;
    private Animator anim;
    private Transform target;
    private SpriteRenderer spRenderer;

    private float speed = .4f;
    //private int damage = 10;
    [SerializeField] Transform player;

    private Rigidbody2D rb2d;
    private Vector2 distance;
    private float power = 2f;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = point2.transform;
        spRenderer = GetComponent<SpriteRenderer>();
        rb2d= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int playerLayer = 1 << 8;
        Vector2 rayDirection = Vector2.left;
        RaycastHit2D ray = Physics2D.BoxCast(transform.position, new Vector2 (4, 0.2f), 180, rayDirection, rayRange, playerLayer);

        if (ray)
        {
            if (ray.collider.gameObject.CompareTag("Player"))
            {
                speed = .9f;
                anim.SetBool("isAttacking", true);
                target = player;
                if (player.position.x - transform.position.x > 0) spRenderer.flipX = true;
                else spRenderer.flipX = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, target.position) < 0.1)
            {
                if (target == point2.transform)
                {
                    target = point1.transform;
                    spRenderer.flipX = true;
                }
                else if (target == point1.transform)
                {
                    target = point2.transform;
                    spRenderer.flipX = false;
                }
            }
            speed = .4f;
            anim.SetBool("isAttacking", false);
            if(target == player)
            {
                target = point2.transform;
                spRenderer.flipX = false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            distance = transform.position - collision.transform.position;
            rb2d.AddForce(distance.normalized * power, ForceMode2D.Impulse);
        }
    }

    public void UnHit()
    {
        anim.SetBool("isHit", false);
    }
    public void BatDead()
    {
        this.gameObject.SetActive(false);
    }
}
