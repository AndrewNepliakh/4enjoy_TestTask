
using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Controllers
{
    public class HealthPanelController : Panel, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _healthText;

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
            _userManager = args[Constants.USER_MANAGER] as UserManager;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
           
        }

        public void UpdateTimer(string value)
        {
            if (_userManager.CurrentUser.Health >= Constants.START_HEALTH_VALUE)
            {
                _timerText.text = "Full";
                return;
            }

            _timerText.text = value;
        }
    }
}