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

        private IPanel _healthPanel;
        private IButtonsSwitchableWindow _floatingWindow;

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

            var timer = Constants.FULL_TEXT;
            
            if (_userManager.CurrentUser.Health != Constants.START_HEALTH_VALUE)
            {
                timer = UpdateTimer();
            }
            
            if (_healthPanel != null)
            {
                _healthPanel.TimerText.text = timer;
                _healthPanel.HealthText.text = UpdateHealth();
            }
            
            if (_floatingWindow != null)
            {
                _floatingWindow.TimerText.text = timer;
                _floatingWindow.HealthText.text = UpdateHealth();
                _floatingWindow.CheckForSwitchingButtons();
            }
        }

        private string UpdateHealth()
        {
            return _userManager.CurrentUser.Health.ToString();
        }

        private string UpdateTimer()
        {
            var value = _timerManager.CalculateTime();
            return _userManager.CurrentUser.Health >= Constants.START_HEALTH_VALUE ? Constants.FULL_TEXT : value;
        }

        private void OpenFloatingWindow()
        {
            var args = new Hashtable
            {
                { Constants.UI_MANAGER, _uiManager },
                { Constants.USER_MANAGER, _userManager }
            };
            _floatingWindow = _uiManager.ShowWindow<FloatingWindowController>(Constants.FLOATING_WINDOW_PATH, args);
        }
    }
}