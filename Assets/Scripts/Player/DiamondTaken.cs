using UnityEngine;

public class DiamondTaken : MonoBehaviour
{
    [SerializeField] GameObject cameraShakeTrigger;
    [SerializeField] GameObject diamond;
    private bool diamondAcquired;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            diamondAcquired = diamond.GetComponent<PickUpItem>().itemAcquired;
            if (diamondAcquired)
                cameraShakeTrigger.SetActive(true);
        }
    }        
}
