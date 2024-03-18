using UnityEngine;

public class BatChecksForPlayer : MonoBehaviour
{
    [SerializeField] private float rayRange;
    private bool idle = true;
    private float speed = .4f;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        int playerLayer = 1 << 8;
        Vector2 rayDirection = Vector2.left;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.TransformDirection(rayDirection) * rayRange, .7f, playerLayer);
        Debug.DrawRay(transform.position, transform.TransformDirection(rayDirection) * rayRange);
        if (ray) {
            if (ray.collider.gameObject.CompareTag("Player"))
            {
                idle = false;
                speed = .6f;
                anim.SetBool("isAttacking", true);
            }
        }
        else
        {
            idle = true;
            speed = .4f;
            anim.SetBool("isAttacking", false);
            //target = point2.transform;
        }
    }
}
