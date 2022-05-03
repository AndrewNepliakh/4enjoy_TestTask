using System;
using UnityEditor;
using UnityEngine;

namespace Managers.StateManager
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}
