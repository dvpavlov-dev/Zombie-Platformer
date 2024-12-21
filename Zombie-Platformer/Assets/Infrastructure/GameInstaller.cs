using UnityEngine;
using Zenject;

namespace Zombie_Platformer.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Configs _configs;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindConfigs();
        }
        
        private void BindConfigs()
        {
            Container
                .Bind<Configs>()
                .FromInstance(_configs)
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .FromInstance(new InputService())
                .AsSingle();
        }
    }
}