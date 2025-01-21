using System.Collections;
using UnityEngine;
using Zenject;

namespace Zombie_Platformer.Infrastructure
{
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        private IFactoryActors _factoryActors;
        private IGameProcess _gameProcess;

        private Vector3 _targetPos;

        [Inject]
        private void Constructor(IFactoryActors factoryActors, IGameProcess gameProcess)
        {
            _gameProcess = gameProcess;
            _factoryActors = factoryActors;
        }

        public void StartSpawner(Transform targetPos)
        {
            StartCoroutine(SpawnEnemies(targetPos));
        }

        private IEnumerator SpawnEnemies(Transform targetPos)
        {
            WaitForSeconds waitForSeconds = new(Random.Range(3, 6));

            while (!_gameProcess.IsGameOver)
            {
                Vector3 spawnPos = targetPos.position;
                spawnPos.x += Random.value > 0.5f ? -12 : 12;

                switch (Random.Range(0, 5))
                {
                    case 0:
                        _factoryActors.CreateBaseEnemy(spawnPos, targetPos.position);
                        break;

                    case 1:
                        _factoryActors.CreateAdvanceEnemy(spawnPos, targetPos.position);
                        break;

                    case 2:
                        _factoryActors.CreateEliteEnemy(spawnPos, targetPos.position);
                        break;

                    case 3:
                        _factoryActors.CreateTankEnemy(spawnPos, targetPos.position);
                        break;

                    case 4:
                        _factoryActors.CreateFastEnemy(spawnPos, targetPos.position);
                        break;

                    default:
                        _factoryActors.CreateBaseEnemy(spawnPos, targetPos.position);
                        break;
                }


                yield return waitForSeconds;
            }
        }
    }
}