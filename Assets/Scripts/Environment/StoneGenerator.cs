using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    private float timeToLaunch;
    [SerializeField] Rigidbody2D stone;
    [SerializeField] Transform pointOfOrigin;
    private void Start()
    {
        timeToLaunch = 7f;
    }
    private void Update()
    {
        timeToLaunch -= Time.deltaTime;
        if (timeToLaunch <= 0)
        {
            LaunchAStone();
        }
    }

    private void LaunchAStone()
    {
        Rigidbody2D stoneInstantiate;
        stoneInstantiate = Instantiate(stone, pointOfOrigin.position, pointOfOrigin.rotation) as Rigidbody2D;
        timeToLaunch = Random.Range(2f, 5f);
    }
}
