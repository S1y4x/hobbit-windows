using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private float xAxis;
    private Rigidbody2D rb2d;
    private Animator rbAnimator;

    private bool right = true;
    private bool isGrounded;
    private bool isJumping;
    private float jumpHeight = 140f;
    public bool isBlocking;

    [SerializeField] Rigidbody2D projectile;
    [SerializeField] Transform firePoint;

    private Vector2 distance;
    private float power = 4f;

    private bool dead = true;

    [SerializeField] Transform respawn;

    [SerializeField] AudioSource slingShot;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource hit;
    [SerializeField] AudioSource block;

    private float playerHealth;
    private int damage = 10;

    [SerializeField] private GameObject levelExit;
    private bool levelIsOver;

    public Text yourCoins;
    public Text yourCoinsPause;
    public int coinsGathered = 0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rbAnimator = GetComponent<Animator>();
        StartCoroutine(ReturnControl(5));           //Set initial time when control is taken away
    }

    void Update()
    {
        levelIsOver = levelExit.GetComponent<LevelExitConditions>().levelIsOver;
        if (!dead)
        {
            xAxis = Input.GetAxisRaw(GlobalVariables.HORIZONTAL);
            isJumping = Input.GetButtonDown(GlobalVariables.JUMP);

            if (Input.GetButton(GlobalVariables.ATTACK))
                rbAnimator.SetBool("isAttacking", true);
            else
                rbAnimator.SetBool("isAttacking", false);

            if (Input.GetButton(GlobalVariables.BLOCK))
            {
                rbAnimator.SetBool("isBlocking", true);
                isBlocking = true;
            }
            else
            {
                rbAnimator.SetBool("isBlocking", false);
                isBlocking = false;
        }

            if (Input.GetButtonDown("Left") && right)
            {
                right = false;
                transform.Rotate(0, 180, 0);
            }
            else if (Input.GetButtonDown("Right") && !right)
            {
                right = true;
                transform.Rotate(0, 180, 0);
            }

            if (isGrounded)
            {
                if (xAxis != 0 && !isJumping && !isBlocking)
                {
                    rb2d.velocity = new Vector2(xAxis, rb2d.velocity.y);
                    rbAnimator.SetBool("isRunning", true);
                    rbAnimator.SetBool("isJumping", false);
                }
                else if (isJumping && !isBlocking)
                {
                    rbAnimator.SetBool("isRunning", false);
                    rbAnimator.SetBool("isJumping", true);
                    rb2d.AddForce(new Vector2(0, jumpHeight));
                    rb2d.velocity = new Vector2(xAxis, rb2d.velocity.y);
                    isGrounded = false;
                    jump.Play();
                }
                else
                {
                    rbAnimator.SetBool("isRunning", false);
                    rbAnimator.SetBool("isJumping", false);
                }
            }
            else
            {
                rb2d.velocity = new Vector2(xAxis, rb2d.velocity.y);
                rbAnimator.SetBool("isRunning", false);
                rbAnimator.SetBool("isJumping", true);
            }
        }
        playerHealth = GetComponent<EnemyHealth>().currentHealth;
        if (playerHealth <= 0)
            PlayerDead();

        if (levelIsOver)
            dead = true;
    }
    private void ShootABall()
    {
        Rigidbody2D projectileInstance;
        projectileInstance = Instantiate(projectile, firePoint.position, firePoint.rotation) as Rigidbody2D;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            distance = transform.position - collision.transform.position;
            rb2d.AddForce(distance.normalized * power, ForceMode2D.Impulse);
            dead = true;
            StartCoroutine(ReturnControl(.3f));

            if (isBlocking)
            {
                rbAnimator.Play("HobbitBlock");
                block.Play();
            }
            else
            {
                hit.Play();
                this.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                rbAnimator.SetBool("isHit", true);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rbAnimator.SetBool("BlockIsHit", false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsGathered += 1;
            string coinsAgreement;
            if (coinsGathered == 1)
            {
                coinsAgreement = "coin";
            }
            else
            {
                coinsAgreement = "coins";
            }
            yourCoins.text = $"You gathered {coinsGathered.ToString()} {coinsAgreement} out of 10";
            yourCoinsPause.text = coinsGathered.ToString() + " " + coinsAgreement;
        }
    }
    public void PlayerDead()
    {
        rbAnimator.SetBool("isDead", true);
        this.gameObject.layer = LayerMask.NameToLayer("Water");
        dead = true;
        GetComponent<EnemyHealth>().TakeDamage(1000);
    }
    public void SlingShotSoundPlay()
    {
        slingShot.Play();
    }
    public void WasHitSetFalse()
    {
        rbAnimator.SetBool("isHit", false);
    }
    private IEnumerator ReturnControl(float time)
    {
        yield return new WaitForSeconds(time);
        dead = false;
    }
}
