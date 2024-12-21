using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField, Range(0,1)] private float _parallaxFactor;

    private Vector3 _prevPos;
    
    void Start()
    {
        _prevPos = _target.transform.position;
    }

    void Update()
    {
        Vector3 pos = _target.transform.position - _prevPos;
        transform.position += pos * _parallaxFactor;

        _prevPos = _target.transform.position;
    }
}
