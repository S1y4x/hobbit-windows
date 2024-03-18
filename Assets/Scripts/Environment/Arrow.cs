using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] AudioSource arrowSound;
    public GameObject arrow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            arrow.SetActive(true);
            arrowSound.Play();
            Destroy(this);
        }
    }
}
