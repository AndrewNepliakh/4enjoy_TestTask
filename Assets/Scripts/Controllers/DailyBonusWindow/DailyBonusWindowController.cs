using System;
using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.DailyBonusWindow
{
    public class DailyBonusWindowController : Window
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private Button _claimButton;
        
        private UIManager _uiManager;

        public override void Show(Hashtable args)
        {
            _uiManager = _uiManager = args[Constants.UI_MANAGER] as UIManager;
            _coinsText.text = $"Get coins: {args[Constants.DAILY_BONUS_COINS_VALUE] as string}";
            _claimButton.onClick.AddListener(OnClose);
        }

        public override void Close()
        {
            _claimButton.onClick.RemoveListener(OnClose);
            base.Close();
        }

        private void OnClose()
        {
            _uiManager.CloseWindow<DailyBonusWindowController>();
        }
    }
}