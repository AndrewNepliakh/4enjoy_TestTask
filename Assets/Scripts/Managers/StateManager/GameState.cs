using System;
using UnityEngine;

namespace Managers.StateManager
{
    public class GameState : IState, IUpdatable
    {
        public void Enter()
        {
           Debug.LogError("Enter GameSate");
        }

        public void Exit()
        {
           
        }

        public void Update()
        {
            
        }
    }
}