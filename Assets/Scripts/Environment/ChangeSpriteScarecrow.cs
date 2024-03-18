using UnityEngine;

public class ChangeSpriteScarecrow : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.sprite = newSprite;
    }
}
