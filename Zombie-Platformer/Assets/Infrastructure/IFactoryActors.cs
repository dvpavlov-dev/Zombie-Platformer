using UnityEngine;

namespace Zombie_Platformer.Infrastructure
{
    public interface IFactoryActors
    {
        public GameObject CreatePlayer();

        public GameObject CreateBaseEnemy(Vector3 spawnPos, Vector3 targetPos);
        public GameObject CreateAdvanceEnemy(Vector3 spawnPos, Vector3 targetPos);
        public GameObject CreateEliteEnemy(Vector3 spawnPos, Vector3 targetPos);
        public GameObject CreateTankEnemy(Vector3 spawnPos, Vector3 targetPos);
        public GameObject CreateFastEnemy(Vector3 spawnPos, Vector3 targetPos);
    }
}