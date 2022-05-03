using System;
using System.Collections.Generic;
using UnityEngine;

public static class UserManager
{
    private static User _currentUser;

    public static User CurrentUser
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

    public static void Init(UserData userData)
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