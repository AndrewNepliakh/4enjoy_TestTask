using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers.StateManager
{
    public class StateManager
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public StateManager()
        {
            _states = new Dictionary<Type, IState>
            {
                {typeof(InitialState), new InitialState()},
                {typeof(GameState), new GameState()}
            };
        }

        public IState EnterState<T>() where T : IState
        {
            _activeState?.Exit();
            var state = _states[typeof(T)];
            _activeState = state;
            state.Enter();
            return state;
        }
    }
}