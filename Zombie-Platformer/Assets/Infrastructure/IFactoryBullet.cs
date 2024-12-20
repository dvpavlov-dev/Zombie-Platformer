using UnityEngine;
public interface IFactoryBullet
{
    public GameObject GetBullet(Vector3 dir);
    public void DisposeBullet(GameObject bullet);
}