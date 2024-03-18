using UnityEngine;

public class MainMenuSceneAction : MonoBehaviour
{
    [SerializeField] GameObject hobbit;
    [SerializeField] GameObject[] objectsOnTheTable;

    private Animator hobbitAnimator;
    private SpriteRenderer hobbitSprite;
    private int index = 0;
    private bool goRight = true;

    private void Start()
    {
        hobbitAnimator = hobbit.GetComponent<Animator>();
        hobbitSprite = hobbit.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (hobbit.transform.position.x < -5f)
            goRight= true;

        if (goRight && index < 3)
        {
            hobbitSprite.flipX = false;
            hobbit.transform.position = Vector2.MoveTowards(hobbit.transform.position, new Vector2 (-1, transform.position.y), .005f);
            hobbitAnimator.SetBool("isRunning", true);
        }
        else if(goRight && index >= 3)
        {
            hobbitAnimator.SetBool("isRunning", false);
        }
        else
        {
            objectsOnTheTable[index].SetActive(true);
            hobbitSprite.flipX = true;
            hobbit.transform.position = Vector2.MoveTowards(hobbit.transform.position, new Vector2(-6, transform.position.y), .005f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            index++;
            goRight = !goRight;
        }
    }
}
