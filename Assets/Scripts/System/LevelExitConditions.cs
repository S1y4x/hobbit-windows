using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelExitConditions : MonoBehaviour
{
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject torch;
    [SerializeField] private GameObject textBox;
    [SerializeField] private Text iNeedATorch;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject winScreen;
    private Vector3 offset = new Vector3(-.2f, .3f, 0);

    private bool itemAcquired;
    public bool levelIsOver;

    [SerializeField] GameObject player;
    private Rigidbody2D playerRB;
    public bool endLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (barrel == null)
            {
                    itemAcquired = torch.GetComponent<PickUpItem>().itemAcquired;
                    if (itemAcquired)
                    {
                        levelIsOver = true;
                        switch (SceneManager.GetActiveScene().buildIndex)
                        {
                            case 1:
                                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                                break;
                            case 2:
                                mainCamera.GetComponent<CameraManager>().LevelIsOver();
                                break;
                            case 3:
                                mainCamera.GetComponent<CameraManager2Level>().LevelIsOver();
                                break;
                            case 4:
                                mainCamera.GetComponent<CameraManager>().LevelIsOver();
                                break;
                            case 5:
                                mainCamera.GetComponent<CameraManager>().LevelIsOver();
                                break;
                        }

                    }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                itemAcquired = torch.GetComponent<PickUpItem>().itemAcquired;
                if (!itemAcquired)
                {
                    textBox.transform.position = collision.gameObject.transform.position + offset;
                    textBox.SetActive(true);
                }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textBox.SetActive(false);
        }

        if (endLevel)
        {
            player.SetActive(false);
            winScreen.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (endLevel)
        {
            playerRB.velocity = new Vector2(0.5f, playerRB.velocity.y);
            //playerRB.velocity = Vector2.right * 0.5f;
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                torch.SetActive(true);
                SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
                playerSprite.sortingOrder = -3;
                torch.transform.position = player.transform.position - new Vector3(0.1f, 0, 0);
                SpriteRenderer torchSprite = torch.GetComponent<SpriteRenderer>();
                torchSprite.sortingOrder = -3;
                torch.transform.SetParent(player.transform);
            }
        }
    }
    public void PlayerLeavesLevel()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        endLevel = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
