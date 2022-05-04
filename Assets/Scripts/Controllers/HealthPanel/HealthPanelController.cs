
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controllers
{
    public class HealthPanelController : Panel, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _healthText;

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

        public void OnPointerClick(PointerEventData eventData)
        {
           
        }

        public void UpdateTimer(string value)
        {
            
        }
    }
}