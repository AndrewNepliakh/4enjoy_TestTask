using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.FloatingWindow
{
    public class FloatingWindowController : Window, IButtonsSwitchableWindow
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

        private IUIManager _uiManager;
        private IUserManager _userManager;

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
            _userManager = args[Constants.USER_MANAGER] as UserManager;
            
            _darker.FadeInDarker();
            _sliderContainer.SlideIn();
            _darker.OnClick += OnCloseButtonClick;
            
            _closeButton.onClick.AddListener(OnCloseButtonClick);
            _useLifeButton.onClick.AddListener(OnUseLifeButtonClick);
            _refillLivesButton.onClick.AddListener(OnRefillLivesButtonClick);
        }
        
        public override void Close()
        {
            _container.SetActive(true);

            _darker.OnComplete -= OnClose;
            _darker.OnClick -= OnCloseButtonClick;

            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
            _useLifeButton.onClick.RemoveListener(OnUseLifeButtonClick);
            _refillLivesButton.onClick.RemoveListener(OnRefillLivesButtonClick);
            
           base.Close();
        }

        public void CheckForSwitchingElements()
        {
            if (_userManager.CurrentUser.Health >= Constants.START_HEALTH_VALUE)
            {
                _useLifeButton.gameObject.SetActive(true);
                _refillLivesButton.gameObject.SetActive(false);
                _timerText.gameObject.SetActive(false);
                return;
            }

            if (_userManager.CurrentUser.Health <= 0)
            {
                _useLifeButton.gameObject.SetActive(false);
                _refillLivesButton.gameObject.SetActive(true);
                _timerText.gameObject.SetActive(true);
                return;
            }
            
            _useLifeButton.gameObject.SetActive(true);
            _refillLivesButton.gameObject.SetActive(true);
            _timerText.gameObject.SetActive(true);
        }

        private void OnCloseButtonClick()
        {
            if(CheckForMotion()) return;
            
            _darker.FadeOutDarker();
            _sliderContainer.SlideOut();
            _darker.OnComplete += OnClose;
        }

        private void OnUseLifeButtonClick()
        {
            _userManager.CurrentUser.Health--;
            _userManager.CurrentUser.Timer = Constants.START_TIME_VALUE;
        }

        private void OnRefillLivesButtonClick()
        {
            _userManager.CurrentUser.Health = Constants.START_HEALTH_VALUE;
            _userManager.CurrentUser.Timer = Constants.START_TIME_VALUE;
        }

        private void OnClose()
        {
            _uiManager.CloseWindow<FloatingWindowController>();
        }

        private bool CheckForMotion() => _darker.IsMoving;
    }
}