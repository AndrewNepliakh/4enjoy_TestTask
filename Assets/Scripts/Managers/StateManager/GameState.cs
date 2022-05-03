using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameState : IState
    {
        private ITimer _timerManager;
        private UserManager _userManager;
        
        private bool _isStarted;
        
        public void Enter(Hashtable args)
        {
            _timerManager = args[Constants.TIMER_MANAGER] as TimerManager;
            _userManager = args[Constants.USER_MANAGER] as UserManager;
            
            _timerManager.Init(_userManager);
            
            _isStarted = true;
            
            Debug.LogError("Enter GameSate");
        }

        public void Exit()
        {
           
        }

        public void Update()
        {
            if(!_isStarted) return;

           Debug.Log(_timerManager.CalculateTime()); 
        }
    }
}