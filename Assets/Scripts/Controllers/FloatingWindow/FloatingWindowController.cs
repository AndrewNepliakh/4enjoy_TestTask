using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.FloatingWindow
{
    public class FloatingWindowController : Window
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _healthText;
        
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _useLifeButton;
        [SerializeField] private Button _refillLivesButton;

        private UIManager _uiManager;

        public TextMeshProUGUI TimerText
        {
            get => _timerText;
            set => _timerText = value;
        }

        public TextMeshProUGUI HealthText 
        {
            get => _healthText;
            set => _healthText = value;
        }
        
        public override void Show(Hashtable args)
        {
            _uiManager = args[Constants.UI_MANAGER] as UIManager;
            
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }
        
        public override void Close()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
           base.Close();
        }

        private void OnCloseButtonClick()
        {
            _uiManager.CloseWindow<FloatingWindowController>();
        }
    }
}