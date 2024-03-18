using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenCave : MonoBehaviour
{
    [SerializeField] TilemapRenderer frontLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            frontLayer.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            frontLayer.enabled = true;
        }
    }
}
