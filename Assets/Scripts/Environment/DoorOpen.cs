
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private SpriteRenderer doorSprite;

    public void BringSpriteToFront()
    {
        doorSprite = this.gameObject.GetComponent<SpriteRenderer>();
        doorSprite.sortingOrder = 1;
    }
}
