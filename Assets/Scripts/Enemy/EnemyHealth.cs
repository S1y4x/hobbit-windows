using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float currentHealth;
    private Animator anim;

    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();

    }
    private void CheckIsAlive()
    {

        if (currentHealth <= 0)
        {
            transform.gameObject.layer = 4;
            anim.SetBool("isDead", true);
        }
            
    }

    public void Heal(int healAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healAmount;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
