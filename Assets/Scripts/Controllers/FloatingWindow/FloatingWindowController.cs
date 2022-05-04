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
        [Space(20)] 
        [SerializeField] private GameObject _container;
        [SerializeField] private SliderContainer _sliderContainer;
        [SerializeField] private Darker _darker;
        [Space (20)]
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
            if(CheckForMotion()) return;
            
            _uiManager = args[Constants.UI_MANAGER] as UIManager;
            
            _darker.FadeInDarker();
            _sliderContainer.SlideIn();
            _darker.OnClick += OnCloseButtonClick;
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }
        
        public override void Close()
        {
            _container.SetActive(true);
            _darker.OnComplete -= OnClose;
            _darker.OnClick -= OnCloseButtonClick;
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
            
           base.Close();
        }

        private void OnCloseButtonClick()
        {
            if(CheckForMotion()) return;
            
            _darker.FadeOutDarker();
            _sliderContainer.SlideOut();
            _darker.OnComplete += OnClose;
        }

        private void OnClose()
        {
            _uiManager.CloseWindow<FloatingWindowController>();
        }

        private bool CheckForMotion() => _darker.IsMoving;
    }
}