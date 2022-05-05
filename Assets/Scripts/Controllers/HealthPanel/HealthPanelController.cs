
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

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPanelClick?.Invoke();
        }
    }
}