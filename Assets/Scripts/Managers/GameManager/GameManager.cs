using Managers.StateManager;
using UnityEngine;
using Zenject;

namespace Managers.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private StateManager.StateManager _stateManager;
    
        private void Start()
        {
            _stateManager.EnterState<GameState>();
        }
    
    }
}
