using System.Collections;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [Inject] private ITimer _timerManager;
        [Inject] private IUIManager _uiManager;
        [Inject] private IUserManager _userManager;
        [Inject] private IStateManager _stateManager;
        [Inject] private IDailyBonusManager _dailyBonusManager;

        private void Start()
        {
            var args = new Hashtable
            {
                {Constants.UI_MANAGER, _uiManager},
                {Constants.USER_MANAGER, _userManager},
                {Constants.TIMER_MANAGER, _timerManager},
                {Constants.DAILY_BONUS_MANAGER, _dailyBonusManager}
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
