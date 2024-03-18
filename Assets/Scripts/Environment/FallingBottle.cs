
using UnityEngine;

public class FallingBottle : MonoBehaviour
{
    private Collider2D col;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col.enabled = !col.enabled;
            Destroy(this, 2f);
        }
    }
}
