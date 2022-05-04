using System;
using System.Collections;
using Controllers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameState : IState
    {
        private ITimer _timerManager;
        private IUserManager _userManager;
        private IUIManager _uiManager;
        
        private HealthPanelController _healthPanel;
        
        private bool _isStarted;
        
        public void Enter(Hashtable args)
        {
            _timerManager = args[Constants.TIMER_MANAGER] as TimerManager;
            _userManager = args[Constants.USER_MANAGER] as UserManager;
            _uiManager = args[Constants.UI_MANAGER] as UIManager;

            _timerManager.Init(_userManager);
            
            _isStarted = true;

            _healthPanel = _uiManager.ShowPanel<HealthPanelController>(Constants.HEALTH_PANEL_PATH, args);
        }

        public void Exit()
        {
           
        }

        public void Update()
        {
            if(!_isStarted) return;
            _healthPanel.UpdateTimer(_timerManager.CalculateTime());
        }
    }
}