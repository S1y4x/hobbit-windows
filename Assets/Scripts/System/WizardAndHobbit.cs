using UnityEngine;
using UnityEngine.UI;

public class WizardAndHobbit : MonoBehaviour
{
    public Text pressSpace;
    private int index = 0;
    public Text hobbitLine;
    public Text wizardLine;
    [SerializeField] private string[] messages;
    public GameObject wizardCloud;
    public GameObject hobbitCloud;
    public Animator hobbitAnimator;
    public Animator wizardAnimator;
    public Rigidbody2D hobbitRB;
    public Rigidbody2D wizardRB;
    [SerializeField] GameObject stone;

    private bool control = false;
    private void Start()
    {
        wizardCloud.SetActive(true);
        hobbitCloud.SetActive(false);
        wizardLine.text = messages[index];
        index = 1;
    }
    private void Update()
    {
        if (hobbitRB.gameObject.transform.position.x > -2.2f)
        {
            hobbitAnimator.SetBool("isRunning", true);
            hobbitRB.velocity = Vector2.left * .5f;
        }
        else
        {
            hobbitAnimator.SetBool("isRunning", false);
            hobbitRB.velocity = Vector2.zero;
            pressSpace.text = "Tap the screen";
            control = true;
        }
        if (control)
        {
            if (Input.GetButtonDown(GlobalVariables.ATTACK))
            {

                if (index < messages.Length)
                {
                    if (index % 2 == 0)
                    {
                        wizardCloud.SetActive(true);
                        hobbitCloud.SetActive(false);
                        wizardLine.text = messages[index];
                    }

                    else
                    {
                        wizardCloud.SetActive(false);
                        hobbitCloud.SetActive(true);
                        hobbitLine.text = messages[index];
                    }
                    index++;
                }
            }
        }
            if (index == 3)
            {
                if (stone.activeSelf == false)
                {
                    stone.SetActive(true);
                    Rigidbody2D rbTorch = stone.GetComponent<Rigidbody2D>();
                    rbTorch.AddForce(new Vector2(-1.5f, 1), ForceMode2D.Impulse);
                }
            }

            if (index == 8)
            {
                wizardAnimator.SetBool("isWalking", true);
                wizardRB.velocity = Vector2.right;
            }
    }
}
