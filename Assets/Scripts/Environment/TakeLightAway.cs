using UnityEngine;

public class TakeLightAway : MonoBehaviour
{
    [SerializeField] GameObject backgroundMusic;
    [SerializeField] GameObject intenseMusic;
    [SerializeField] GameObject torch;
    [SerializeField] GameObject activeCam;
    [SerializeField] GameObject inactiveCam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            backgroundMusic.SetActive(false);
            intenseMusic.SetActive(true);
            torch.SetActive(false);
            activeCam.SetActive(false);
            inactiveCam.SetActive(true);
        }
    }
}
