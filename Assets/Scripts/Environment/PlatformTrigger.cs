using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] SliderJoint2D sliderJ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sliderJ.autoConfigureAngle = true;
            sliderJ.angle = 1f;
            Destroy(this);
        }
    }
}
