using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

namespace Zombie_Platformer
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private FactoryActors _factoryActors;
        [SerializeField] private FactoryBullet _factoryBullet;

        public override void InstallBindings()
        {
            BindFactoryActors();
            BindFactoryBullet();
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