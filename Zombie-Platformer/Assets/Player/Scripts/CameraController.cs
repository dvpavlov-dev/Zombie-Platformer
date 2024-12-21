using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _mainCamera;
    private const int OFFSET_COEFFICIENT = 5;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 camPos = transform.position;
        camPos.y = 0;
        camPos.z = -10;

        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, camPos, Time.deltaTime * OFFSET_COEFFICIENT);
    }
}
