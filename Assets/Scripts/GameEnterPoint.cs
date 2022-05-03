using System.Collections;
using Managers;
using UnityEngine;
using Zenject;

public class GameEnterPoint : MonoBehaviour
{
    [Inject] private StateManager _stateManager;
    [Inject] private UserManager _userManager;
    
    private void Awake()
    {
        var args = new Hashtable {{Constants.USER_MANAGER, _userManager}};
        _stateManager.EnterState<InitialState>(args);
    }
}