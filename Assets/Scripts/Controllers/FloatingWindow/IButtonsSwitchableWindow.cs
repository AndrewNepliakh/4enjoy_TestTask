using TMPro;

namespace Controllers.FloatingWindow
{
    public interface IButtonsSwitchableWindow : IWindow
    {
        TextMeshProUGUI TimerText { get; set; }
        TextMeshProUGUI HealthText { get; set; }
        void CheckForSwitchingElements();
    }
}