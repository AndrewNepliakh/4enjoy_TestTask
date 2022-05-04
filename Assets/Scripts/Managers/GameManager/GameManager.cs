using System.Collections;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [Inject] private IStateManager _stateManager;
        [Inject] private ITimer _timerManager;
        [Inject] private IUserManager _userManager;
        [Inject] private IUIManager _uiManager;

        private void Start()
        {
            var args = new Hashtable
            {
                {Constants.TIMER_MANAGER, _timerManager},
                {Constants.USER_MANAGER, _userManager},
                {Constants.UI_MANAGER, _uiManager}
            };
            
            _stateManager.EnterState<GameState>(args);
        }

        private void Update()
        { 
            _stateManager.ActiveState.Update();
        }

        private void OnApplicationQuit()
        {
           SaveManager.Save(_userManager);
        }
    }
}
