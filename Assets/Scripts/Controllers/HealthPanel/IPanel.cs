using System;
using System.Collections;
using TMPro;

namespace Controllers
{
    public interface IPanel
    {
        Action OnPanelClick { get; set; }
        TextMeshProUGUI TimerText { get; set; }
        TextMeshProUGUI HealthText { get; set; }
        void Show(Hashtable args);
        
    }
}