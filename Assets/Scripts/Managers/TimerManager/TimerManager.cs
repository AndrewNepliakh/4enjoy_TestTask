using UnityEngine;

namespace Managers
{
    public class TimerManager : ITimer
    {
        private IUserManager _userManager;

        public void Init(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public string CalculateTime()
        {
            _userManager.CurrentUser.Timer -= Time.deltaTime;

            if (_userManager.CurrentUser.Timer <= 0)
            {
                _userManager.CurrentUser.Timer = Constants.START_TIME_VALUE;
                _userManager.CurrentUser.Health++;
            }

            return FormatTime(_userManager.CurrentUser.Timer);
        }

        private string FormatTime(float time)
        {
            var minutes = (int)time / 60;
            var seconds = (int)time - 60 * minutes;
            return $"{minutes:00}:{seconds:00}";
        }
    }
}