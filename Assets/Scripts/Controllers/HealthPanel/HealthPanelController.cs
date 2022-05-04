
using System;
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
        public override Action OnPanelClick { get; set; }

        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _healthText;

        private IUserManager _userManager;

        public override TextMeshProUGUI TimerText
        {
            get => _timerText;
            set => _timerText = value;
        }

        public override TextMeshProUGUI HealthText 
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
            OnPanelClick?.Invoke();
        }
    }
}