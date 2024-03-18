using UnityEngine;

public class StoneCreator : MonoBehaviour
{
    [SerializeField] GameObject stone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stone.SetActive(true);
        }
    }
}
