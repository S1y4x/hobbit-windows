using UnityEngine;

public class Barrel : MonoBehaviour
{
    public Rigidbody2D explosion;
    public Transform explosionPlace;
    public AudioSource explosionSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            explosionSound.Play();
            Rigidbody2D explosionInstance;
            explosionInstance = Instantiate(explosion, explosionPlace.position, explosionPlace.rotation);
            Destroy(this.gameObject);
    }
    }
}
