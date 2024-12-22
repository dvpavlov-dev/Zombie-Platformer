using UnityEngine;
using Zenject;
using Zombie_Platformer.Enemy;

namespace Zombie_Platformer.Infrastructure
{
    public class FactoryActors : MonoBehaviour, IFactoryActors
    {
        [Header("Player")]
        [SerializeField] private GameObject _payerPrefab;

        [Header("Enemies")]
        [SerializeField] private GameObject _baseEnemyPrefab;
        [SerializeField] private GameObject _advanceEnemyPrefab;
        [SerializeField] private GameObject _eliteEnemyPrefab;
        [SerializeField] private GameObject _tankEnemyPrefab;
        [SerializeField] private GameObject _fastEnemyPrefab;
        
        private Configs _configs;

        [Inject]
        private void Constructor(Configs configs)
        {
            _configs = configs;

        }
        
        public GameObject CreatePlayer()
        {
            return Instantiate(_payerPrefab);
        }

        public GameObject CreateBaseEnemy(Vector3 spawnPos, Vector3 targetPos)
        {
            return CreateEnemy(_baseEnemyPrefab, spawnPos, targetPos, _configs.BaseEnemyConfig);;
        }

        public GameObject CreateAdvanceEnemy(Vector3 spawnPos, Vector3 targetPos)
        {
            return CreateEnemy(_advanceEnemyPrefab, spawnPos, targetPos, _configs.AdvanceEnemyConfig);;
        }

        public GameObject CreateEliteEnemy(Vector3 spawnPos, Vector3 targetPos)
        {
            return CreateEnemy(_eliteEnemyPrefab, spawnPos, targetPos, _configs.EliteEnemyConfig);;
        }

        public GameObject CreateTankEnemy(Vector3 spawnPos, Vector3 targetPos)
        {
            return CreateEnemy(_tankEnemyPrefab, spawnPos, targetPos, _configs.TankEnemyConfig);;
        }

        public GameObject CreateFastEnemy(Vector3 spawnPos, Vector3 targetPos)
        {
            return CreateEnemy(_fastEnemyPrefab, spawnPos, targetPos, _configs.FastEnemyConfig);;
        }
        
        private GameObject CreateEnemy(GameObject enemyPrefab, Vector3 spawnPos, Vector3 targetPos, EnemyConfigSource enemyConfig)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            enemy.GetComponent<Enemy.Enemy>().Init(enemyConfig);
            enemy.GetComponent<EnemyMoveComponent>().Init(targetPos, enemyConfig);
            return enemy;
        }
    }
}