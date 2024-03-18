using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] Transform respawn;
    [SerializeField] GameObject player;
    private float playerHealth;
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<EnemyHealth>().TakeDamage(damage);
            playerHealth = player.GetComponent<EnemyHealth>().currentHealth;
            if (playerHealth > 0.1f)
            {
                LevelRestart();
            }
        }
    }
    public void LevelRestart()
    {

        player.transform.position = respawn.position;
    }
}
