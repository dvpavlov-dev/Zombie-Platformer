using Unity.Mathematics;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private Transform _bulletSprite;
    private IFactoryBullet _factoryBullet;
    private Vector3 _dir;

    public void Init(IFactoryBullet factoryBullet, Vector3 dir)
    {
        _dir = dir;
        _bulletSprite.rotation = Quaternion.Euler(0,0, _dir.x < 0 ? 90 : -90);
        _factoryBullet = factoryBullet;
        Invoke(nameof(DisposeBullet), 1f);
    }
    
    void Update()
    {
        transform.Translate(_dir.x * Time.deltaTime * _speed, 0, 0);
    }

    private void DisposeBullet()
    {
        _factoryBullet.DisposeBullet(gameObject);
    }
}
