using Managers.StateManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameEnterPoint : MonoBehaviour
{
    [Inject] private StateManager _stateManager;
    private void Awake()
    {
       _stateManager.EnterState<InitialState>();
    }
}