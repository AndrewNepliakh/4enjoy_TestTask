using UnityEngine;

namespace Managers
{
    public class TimerManager : ITimer
    {
       private IUserManager _userManager;
        
        private IUser _currentUser;
        private float _timer; // In seconds

        public void Init(IUserManager userManager)
        {
            _userManager = userManager;
            _currentUser = _userManager.CurrentUser;
            _timer = _currentUser.Timer;
        }

        public string CalculateTime()
        {
            _timer -= Time.deltaTime;
            
            if (_timer <= 0) _timer = Constants.START_TIME_VALUE;

            _currentUser.Timer = _timer;
            return FormatTime(_timer);
        }
        
        private string FormatTime(float time)
        {
            var minutes = (int) time / 60 ;
            var seconds = (int) time - 60 * minutes;
            return $"{minutes:00}:{seconds:00}";
        }
    }
}