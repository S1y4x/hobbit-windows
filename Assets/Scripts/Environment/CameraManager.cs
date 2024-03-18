using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject cam1;
    [SerializeField] Transform upperCache;
    [SerializeField] Transform lowerCache;

    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;
    private int numberOfLayers;

    Vector2 targetPos;
    private bool unCache;
    private bool reCache;

    [SerializeField] GameObject endLevel;
    private void Start()
    {
        StartCoroutine(timer());
        targetPos = new Vector2(upperCache.position.x, 120);
        numberOfLayers = layers.Length;
    }
    private void Update()
    {
        for(int i = 0; i < numberOfLayers; i++)
        {
            layers[i].position = new Vector3(transform.position.x * coeff[i], transform.position.y, transform.position.z);
        }
    }
    private void FixedUpdate()
    {
        if (unCache)
        {
            upperCache.transform.Translate(Vector2.up * .005f, Space.Self);
            lowerCache.transform.Translate(Vector2.down * .005f, Space.Self);
        }

        if (reCache)
        {
            upperCache.transform.Translate(Vector2.down * .005f, Space.Self);
            lowerCache.transform.Translate(Vector2.up * .005f, Space.Self);
        }
    }
    private IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        cam1.SetActive(false);
        yield return new WaitForSeconds(4);
        unCache = true;
        yield return new WaitForSeconds(1);
        unCache = false;
    }

    public void LevelIsOver()
    {
        StartCoroutine(exitTimer());
        endLevel.GetComponent<LevelExitConditions>().PlayerLeavesLevel();
    }
    private IEnumerator exitTimer()
    {
        yield return new WaitForSeconds(1);
        reCache = true;
        yield return new WaitForSeconds(1);
        reCache = false;
    }
}