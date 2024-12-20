using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _mainCamera;
    
    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 camPos = transform.position;
        camPos.y = 0;
        camPos.z = -10;

        _mainCamera.transform.position = camPos;
    }
}
