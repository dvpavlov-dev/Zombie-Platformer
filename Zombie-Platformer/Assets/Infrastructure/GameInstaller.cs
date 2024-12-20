using Zenject;

namespace Zombie_Platformer.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
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