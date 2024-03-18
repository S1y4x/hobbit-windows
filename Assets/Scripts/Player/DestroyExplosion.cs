using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, .8f);
    }
}
