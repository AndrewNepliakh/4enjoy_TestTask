using UnityEngine.SceneManagement;
using Zenject;

namespace Managers.StateManager
{
    public class InitialState : IState
    {
        [Inject] private StateManager _stateManager;

        public void Enter()
        {
            LoadUserData();
            SceneManager.LoadScene(Constants.MAIN_SCENE);
        }

        public void Exit()
        {
           
        }

        private void LoadUserData()
        {
            var saveData = SaveManager.Load();
            UserManager.Init(saveData.UserData);
        }
    }
}