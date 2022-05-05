using Managers;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _uiManager;
        
        public override void InstallBindings()
        {
            Container.Bind<ITimer>().To<TimerManager>().AsSingle();
            Container.Bind<IDailyBonusManager>().To<DailyBonusManager>().AsSingle();
            Container.Bind<IUIManager>().FromInstance(_uiManager).AsSingle();
        }
    }
}
