using Managers;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StateManager>().AsSingle();
            Container.Bind<UserManager>().AsSingle();
        }
    }
}
