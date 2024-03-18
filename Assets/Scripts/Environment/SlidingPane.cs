using UnityEngine;

public class SlidingPane : MonoBehaviour
{
    private SliderJoint2D sliderJ;
    void Start()
    {
        sliderJ = GetComponent<SliderJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Stone"))
        sliderJ.connectedAnchor = new Vector2(20.852f, 0.016f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
