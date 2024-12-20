using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    
    void Update()
    {
        transform.Translate(Time.deltaTime * _speed, 0, 0);
    }
}
