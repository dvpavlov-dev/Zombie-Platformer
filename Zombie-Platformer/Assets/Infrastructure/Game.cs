using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Zombie_Platformer.Infrastructure
{
    public class Game : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private IFactoryActors _factoryActors;

        [Inject]
        private void Constructor(IFactoryActors factoryActors)
        {
            _factoryActors = factoryActors;
        }
        
        void Start()
        {
            _gameStateMachine = new GameStateMachine(_factoryActors);
            _gameStateMachine.Enter<StartGame>();
        }
    }

    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;

        private IState _currentState;

        public GameStateMachine(IFactoryActors factoryActors)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(StartGame)] = new StartGame(factoryActors),
                [typeof(EndGame)] = new EndGame(),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }

    public class StartGame : IState
    {
        private readonly IFactoryActors _factoryActors;
        
        public StartGame(IFactoryActors factoryActors)
        {
            _factoryActors = factoryActors;
        }

        public void Enter()
        {
            _factoryActors.CreatePlayer();
        }

        public void Exit() {}
    }

    public class EndGame : IState
    {
        public void Enter() {}
        public void Exit() {}
    }
}