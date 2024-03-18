using UnityEngine.UI;
using UnityEngine;

public class HobbitAndWizard : MonoBehaviour
{
    public GameObject hobbit;
    public GameObject wizard;
    public GameObject hobbitCloud;
    public GameObject wizardCloud;
    public Text hobbitLine;
    public Text wizardLine;
    private Animator hobbitAnimator;
    private Animator wizardAnimator;
    public Vector2 hobbitMoving;
    public Vector2 wizardMoving;
    private Vector3 offset = new Vector3(-.1f, .3f, 0);
    private int index;
    [SerializeField] public string[] messages;
    private Rigidbody2D hobbitRB;
    private bool endConversation = false;
    private bool control = false;
    private bool preview = true;
    public Text pressSpace;

    private void Start()
    {
        hobbitRB = hobbit.GetComponent<Rigidbody2D>();
        hobbitAnimator = hobbit.GetComponent<Animator>();
        wizardAnimator = wizard.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (preview)
        { 
        if (hobbit.transform.position.x < hobbitMoving.x)
        {
            hobbit.transform.position = Vector2.MoveTowards(hobbit.transform.position, hobbitMoving, .005f);
            hobbitAnimator.SetBool("isRunning", true);
            hobbitCloud.SetActive(true);
            hobbitCloud.transform.position = hobbit.transform.position + offset;
            hobbitLine.text = "Finally, I can have my third breakfast with no one interrupting me...";
        }
        else
        {
            hobbitAnimator.SetBool("isRunning", false);
            hobbitLine.text = "Wait, who’s that coming there? Isn’t it that old wizard... Not again!";
        }

        if (wizard.transform.position.x > wizardMoving.x)
        {
            wizard.transform.position = Vector2.MoveTowards(wizard.transform.position, wizardMoving, .005f);
            wizardAnimator.SetBool("isWalking", true);

        }
        else
        {
            hobbitCloud.SetActive(false);
            wizardAnimator.SetBool("isWalking", false);
            wizardCloud.SetActive(true);
            wizardLine.text = "There you are little hobbit; I was looking for you everywhere!";
            pressSpace.text = "Tap the screen";
            control = true;
            preview = false;
        }
    }
    }
    private void Update()
    {
        if (control)
        {
            if (Input.GetButtonDown(GlobalVariables.ATTACK))
            {
                if (index < messages.Length)
                {
                    if (index % 2 == 0)
                    {
                        wizardCloud.SetActive(false);
                        hobbitCloud.SetActive(true);
                        hobbitLine.text = messages[index];
                        index++;
                    }
                    else
                    {
                        wizardCloud.SetActive(true);
                        hobbitCloud.SetActive(false);
                        wizardLine.text = messages[index];
                        index++;
                    }
                }
                else
                {
                    endConversation = true;
                    hobbitAnimator.SetBool("isRunning", true);
                    pressSpace.text = "";
                }
            }
            if (endConversation)
            {
                hobbitRB.velocity = Vector2.right;
                hobbitCloud.gameObject.SetActive(false);
            }
        }
    }
}
