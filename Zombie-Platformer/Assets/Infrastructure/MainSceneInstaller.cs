using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

namespace Zombie_Platformer
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private FactoryActors _factoryActors;
        [SerializeField] private FactoryBullet _factoryBullet;
        [SerializeField] private FactoryDrop _factoryDrop;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private UIController _uiController;

        public override void InstallBindings()
        {
            BindFactoryActors();
            BindFactoryBullet();
            BindFactoryDrop();
            
            BindGameProcess();
            BindEnemySpawner();
            BindUIController();
        }
        
        private void BindFactoryDrop()
        {
            Container
                .Bind<IFactoryDrop>()
                .FromInstance(_factoryDrop)
                .AsSingle();
        }

        private void BindUIController()
        {
            Container
                .Bind<IUIController>()
                .FromInstance(_uiController)
                .AsSingle();
        }

        private void BindEnemySpawner()
        {
            Container
                .Bind<IEnemySpawner>()
                .FromInstance(_enemySpawner)
                .AsSingle();
        }

        private void BindGameProcess()
        {
            Container
                .Bind<IGameProcess>()
                .FromInstance(new GameProcess())
                .AsSingle();
        }

        private void BindFactoryBullet()
        {
            Container
                .Bind<IFactoryBullet>()
                .FromInstance(_factoryBullet)
                .AsSingle();
        }

        private void BindFactoryActors()
        {
            Container
                .Bind<IFactoryActors>()
                .FromInstance(_factoryActors)
                .AsSingle();
        }
    }
}