using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameState : IState
    {
        private ITimer _timerManager;
        private UserManager _userManager;
        private TextMeshProUGUI _timerText;
        
        private bool _isStarted;
        
        public void Enter(Hashtable args)
        {
            _timerManager = args[Constants.TIMER_MANAGER] as TimerManager;
            _userManager = args[Constants.USER_MANAGER] as UserManager;
            _timerText = args[Constants.TIMER_TEXT] as TextMeshProUGUI;
            
            _timerManager.Init(_userManager);
            
            _isStarted = true;
        }

        public void Exit()
        {
           
        }

        public void Update()
        {
            if(!_isStarted) return;
            _timerText.text = _timerManager.CalculateTime();
        }
    }
}