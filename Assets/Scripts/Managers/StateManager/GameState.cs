using System;
using System.Collections;
using Controllers;
using Controllers.FloatingWindow;
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
        private FloatingWindowController _floatingWindow;

        private bool _isStarted;

        public void Enter(Hashtable args)
        {
            _timerManager = args[Constants.TIMER_MANAGER] as TimerManager;
            _userManager = args[Constants.USER_MANAGER] as UserManager;
            _uiManager = args[Constants.UI_MANAGER] as UIManager;

            _timerManager.Init(_userManager);

            _isStarted = true;

            _healthPanel = _uiManager.ShowPanel<HealthPanelController>(Constants.HEALTH_PANEL_PATH, args);
            _healthPanel.OnPanelClick += OpenFloatingWindow;
        }

        public void Exit()
        {
            _healthPanel.OnPanelClick -= OpenFloatingWindow;
        }

        public void Update()
        {
            if (!_isStarted) return;

            if (_healthPanel) _healthPanel.TimerText.text = UpdateTimer();
            if (_floatingWindow) _floatingWindow.TimerText.text = UpdateTimer();
        }

        private string UpdateTimer()
        {
            var value = _timerManager.CalculateTime();
            return _userManager.CurrentUser.Health >= Constants.START_HEALTH_VALUE ? "Full" : value;
        }

        private void OpenFloatingWindow()
        {
            var args = new Hashtable { { Constants.UI_MANAGER, _uiManager } };
            _floatingWindow = _uiManager.ShowWindow<FloatingWindowController>(Constants.FLOATING_WINDOW_PATH, args);
        }
    }
}