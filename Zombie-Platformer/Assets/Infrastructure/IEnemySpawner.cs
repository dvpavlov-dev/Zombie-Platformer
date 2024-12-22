using UnityEngine;

namespace Zombie_Platformer.Infrastructure
{
    public interface IEnemySpawner
    {
        public void StartSpawner(Transform targetPos);
    }
}