using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Animator ShootingArrow;
    [SerializeField] AudioSource shootingArrowSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shootingArrowSound.Play();
            ShootingArrow.SetBool("isShooting", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShootingArrow.SetBool("isShooting", false);
        }
    }
}
