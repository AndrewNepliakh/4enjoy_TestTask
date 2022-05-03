using System;
using UnityEngine;

namespace Managers
{
    public class UserManager
    {
        private User _currentUser;

        public User CurrentUser
        {
            get
            {
                try
                {
                    return _currentUser;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Current user is not initialized, coses: {e.Message}");
                    _currentUser = new User();
                    return _currentUser;
                }
            }
        }

        public void Init(UserData userData)
        {
            try
            {
                _currentUser = userData.User;
            }
            catch (Exception e)
            {
                _currentUser = new User();
                Debug.LogError($"Current user is not initialized, coses: {e.Message}");
            }
        }
    }
}