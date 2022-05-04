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
        }
        
        public override void Close()
        {
           base.Close();
        }
    }
}