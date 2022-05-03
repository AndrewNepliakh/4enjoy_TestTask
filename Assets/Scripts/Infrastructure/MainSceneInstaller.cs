using Managers;
using Zenject;

namespace Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().AsSingle().Lazy();
            Container.Bind<TimerManager>().AsSingle().Lazy();
        }
    }
}
