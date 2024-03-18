using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject extraHeart;
    [SerializeField] GameObject torch;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isOpen", true);
        }
    }
    public void ExtraHeart()
    {
        extraHeart.SetActive(true);
        if (torch.activeSelf == false)
        {
            torch.SetActive(true);
            Rigidbody2D rbTorch = torch.GetComponent<Rigidbody2D>();
            rbTorch.AddForce(new Vector2(-1.5f, 1), ForceMode2D.Impulse);
        }
        Rigidbody2D rbExtraHeart = extraHeart.GetComponent<Rigidbody2D>();
        rbExtraHeart.AddForce(Vector2.one * 1.5f, ForceMode2D.Impulse);

    }
}
