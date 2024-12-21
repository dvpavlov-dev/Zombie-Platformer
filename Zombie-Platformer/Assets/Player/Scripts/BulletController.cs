using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private Transform _bulletSprite;
    
    private IFactoryBullet _factoryBullet;
    
    private Vector3 _dir;
    private float _damage;

    public void Init(IFactoryBullet factoryBullet, Vector3 dir, float damage)
    {
        _factoryBullet = factoryBullet;
        _dir = dir;
        _damage = damage;

        _bulletSprite.rotation = Quaternion.Euler(0,0, _dir.x < 0 ? 90 : -90);

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageController>() is {} damageController)
        {
            damageController.TakeDamage(_damage);
            DisposeBullet();
        }
    }
}
