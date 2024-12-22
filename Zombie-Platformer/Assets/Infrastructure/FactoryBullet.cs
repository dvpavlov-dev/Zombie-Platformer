using System.Collections.Generic;
using UnityEngine;
using Zombie_Platformer.Player;

namespace Zombie_Platformer.Infrastructure
{
    public class FactoryBullet : MonoBehaviour, IFactoryBullet
    {
        [SerializeField] private GameObject _bulletPrefab;

        private Queue<GameObject> _bulletsPool = new();
        private GameObject _containerForBullets;

        private void Start()
        {
            CreateBulletsPool();
        }

        public GameObject GetBullet(Vector3 dir, float damage)
        {
            if (_bulletsPool.Count == 0)
            {
                CreateBullet();
            }

            GameObject bullet = _bulletsPool.Dequeue();
            bullet.GetComponent<BulletController>().Init(this, dir, damage);
            bullet.SetActive(true);

            return bullet;
        }

        public void DisposeBullet(GameObject bullet)
        {
            bullet.SetActive(false);
            _bulletsPool.Enqueue(bullet);
        }

        private void CreateBulletsPool()
        {
            _containerForBullets = new GameObject("Container for bullet");

            for (int i = 0; i < 10; i++)
            {
                CreateBullet();
            }
        }

        private void CreateBullet()
        {
            GameObject bullet = Instantiate(_bulletPrefab, _containerForBullets.transform);
            bullet.SetActive(false);
            _bulletsPool.Enqueue(bullet);
        }
    }
}