using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    private float healthValue;
    [SerializeField] SpriteRenderer heart1;
    [SerializeField] SpriteRenderer heart2;
    [SerializeField] SpriteRenderer heart3;
    [SerializeField] Sprite newHeartSprite;
    [SerializeField] Sprite oldHeartSprite;
    [SerializeField] GameObject playerDeadPanel;
    [SerializeField] Button pauseButton;
    private void Update()
    {
        healthValue = GetComponent<EnemyHealth>().currentHealth;
        if (healthValue == 30 && heart3.sprite == newHeartSprite)
        {
            heart2.sprite = oldHeartSprite;
            heart3.sprite = oldHeartSprite;
        }
        if (healthValue == 20) 
        {
            heart3.sprite = newHeartSprite;
            heart2.sprite = oldHeartSprite;
        }
        if (healthValue == 10)
        {
            heart3.sprite = newHeartSprite;
            heart2.sprite = newHeartSprite;
        }
        if (healthValue <= 0)
        {
            pauseButton.interactable = false;
            playerDeadPanel.SetActive(true);
            heart3.sprite = newHeartSprite;
            heart2.sprite = newHeartSprite;
            heart1.sprite = newHeartSprite;
            StartCoroutine(deathTimer());         //auto restart
        }
    }
    private IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
