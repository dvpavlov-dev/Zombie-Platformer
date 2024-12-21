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
        private IGameProcess _gameProcess;
        private IEnemySpawner _enemySpawner;
        private IUIController _uiController;

        [Inject]
        private void Constructor(IFactoryActors factoryActors, IGameProcess gameProcess, IEnemySpawner enemySpawner, IUIController uiController)
        {
            _uiController = uiController;
            _enemySpawner = enemySpawner;
            _gameProcess = gameProcess;
            _factoryActors = factoryActors;
        }
        
        void Start()
        {
            _gameStateMachine = new GameStateMachine(_factoryActors, _gameProcess, _enemySpawner, _uiController);
            _gameStateMachine.Enter<StartGame>();
        }
    }

    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;

        private IState _currentState;

        public GameStateMachine(IFactoryActors factoryActors, IGameProcess gameProcess, IEnemySpawner enemySpawner, IUIController uiController)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(StartGame)] = new StartGame(this, factoryActors, gameProcess, enemySpawner),
                [typeof(EndGame)] = new EndGame(uiController),
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
        private readonly GameStateMachine _gameStateMachine;
        private readonly IFactoryActors _factoryActors;
        private readonly IGameProcess _gameProcess;
        private readonly IEnemySpawner _enemySpawner;

        public StartGame(GameStateMachine gameStateMachine, IFactoryActors factoryActors, IGameProcess gameProcess, IEnemySpawner enemySpawner)
        {
            _gameStateMachine = gameStateMachine;
            _factoryActors = factoryActors;
            _gameProcess = gameProcess;
            _enemySpawner = enemySpawner;
        }

        public void Enter()
        {
            GameObject player = _factoryActors.CreatePlayer();
            _enemySpawner.StartSpawner(player.transform);
            
            _gameProcess.OnGameOver += GameOver;
        }

        public void Exit()
        {
            _gameProcess.OnGameOver -= GameOver;
        }

        private void GameOver()
        {
            _gameStateMachine.Enter<EndGame>();
        }
    }

    public class EndGame : IState
    {
        private readonly IUIController _uiController;
        
        public EndGame(IUIController uiController)
        {
            _uiController = uiController;
        }

        public void Enter()
        {
            _uiController.ShowEndWindow();
        }
        
        public void Exit() {}
    }
}