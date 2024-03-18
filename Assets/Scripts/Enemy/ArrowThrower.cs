using UnityEngine;

public class ArrowThrower : MonoBehaviour
{
    [SerializeField] private Rigidbody2D arrow;
    [SerializeField] Transform firePoint;

    private void ShootAnArrow()
    {
        Rigidbody2D projectileInstance;
        projectileInstance = Instantiate(arrow, firePoint.position, firePoint.rotation) as Rigidbody2D;
    }
}


