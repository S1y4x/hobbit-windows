using UnityEngine;

public class LevelExitAdditional : MonoBehaviour
{
    [SerializeField] Animator door;
    [SerializeField] GameObject wall;
    private bool endLevel;
    void OnTriggerEnter2D()
    {
        endLevel = this.gameObject.GetComponent<LevelExitConditions>().endLevel;
        if (endLevel)
        {
            wall.SetActive(false);
            door.SetBool("isOpen", true);
        }
    }

}
