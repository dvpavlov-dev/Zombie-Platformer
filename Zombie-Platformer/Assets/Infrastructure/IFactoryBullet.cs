using UnityEngine;

namespace Zombie_Platformer.Infrastructure
{
    public interface IFactoryBullet
    {
        public GameObject GetBullet(Vector3 dir, float damage);
        public void DisposeBullet(GameObject bullet);
    }
}