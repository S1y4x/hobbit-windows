using UnityEngine;

public class ChangeSpriteLantern : MonoBehaviour
{
    [SerializeField] GameObject faintLight;
    [SerializeField] Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Transform respawn;
    private Vector3 offset = new Vector3(0, .2f, 0);
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        faintLight.SetActive(true);
        spriteRenderer.sprite = newSprite;
        respawn.transform.position = transform.position - offset;
        Destroy(this);
    }
}
