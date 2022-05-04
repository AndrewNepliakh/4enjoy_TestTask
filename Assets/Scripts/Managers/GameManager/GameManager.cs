using System.Collections;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private StateManager _stateManager;
        [Inject] private TimerManager _timerManager;
        [Inject] private UserManager _userManager;

        [SerializeField] private UIManager _uiManager;

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
