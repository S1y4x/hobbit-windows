using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] GameObject player;
    private float shakeTimer;
    [SerializeField] GameObject stones;
    [SerializeField] GameObject trigger;

    private void Awake()
    {
        _virtualCamera = _camera.GetComponent<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            ShakeCamera(2f, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            CinemachineBasicMultiChannelPerlin _cameraPref = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _cameraPref.m_AmplitudeGain = 0f;
            trigger.SetActive(false);
        }
    }
    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin _cameraPref = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cameraPref.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    private void Update()
    {
        if (_camera.activeSelf)
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                stones.SetActive(true);
            }

            else
            {
                CinemachineBasicMultiChannelPerlin _cameraPref = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                _cameraPref.m_AmplitudeGain = 0f;
            }
        }
    }
}
