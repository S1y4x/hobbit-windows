using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitZero : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
