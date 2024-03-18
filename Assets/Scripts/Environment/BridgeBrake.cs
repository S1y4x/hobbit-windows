using UnityEngine;

public class BridgeBrake : MonoBehaviour
{
    [SerializeField] FixedJoint2D bridge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { Destroy(bridge); }
    }
}
