using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] AudioSource cling;
    public bool itemAcquired;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            itemAcquired = true;
            cling.Play();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            this.gameObject.SetActive(false);
            cling.Play();
        }

    }
}
