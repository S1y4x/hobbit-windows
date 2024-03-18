using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField] AudioSource cling;
    [SerializeField] int healAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().Heal(healAmount);
            this.gameObject.SetActive(false);
            cling.Play();
        }
        
    }
}
