using System;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameStateMachine _gameStateMachine;
    
    void Start()
    {
        _gameStateMachine = new GameStateMachine();
        _gameStateMachine.Enter<StartGame>();
    }
}

public class GameStateMachine
{
    private Dictionary<Type, IState> _states;

    private IState _currentState;
    
    public GameStateMachine()
    {
        _states = new Dictionary<Type, IState>
        {
            [typeof(StartGame)] = new StartGame(),
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

public interface IState
{
    public void Enter();
    public void Exit();
}

public class StartGame : IState
{
    public void Enter()
    {
    }
    
    public void Exit()
    {
    }
}

public class EndGame : IState
{
    public void Enter()
    {
    }
    public void Exit()
    {
    }
}