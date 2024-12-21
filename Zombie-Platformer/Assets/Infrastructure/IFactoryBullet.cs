using UnityEngine;
public interface IFactoryBullet
{
    public GameObject GetBullet(Vector3 dir, float damage);
    public void DisposeBullet(GameObject bullet);
}