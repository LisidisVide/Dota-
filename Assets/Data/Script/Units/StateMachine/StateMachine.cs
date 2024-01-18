using System;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class StateMachine
{
    private Transform _transform;
    private Warrior _warrior;

    public StateMachine(Transform transform, Warrior warrior)
    {
        _transform = transform;
        _warrior = warrior;
    }

    public State CurrentState { get; private set; }
    public Transform Transform => _transform;
    public Warrior Warrior => _warrior;

    private Dictionary<Type, State> _states = new Dictionary<Type, State>();

    public void AddState(State state)
    {
        if (_states.TryGetValue(state.GetType(), out State s))
            throw new NotImplementedException();

        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : State
    {
        if (CurrentState != null && CurrentState.GetType() == typeof(T))
            return;

        if(_states.TryGetValue(typeof(T), out State newState))
        {
            Debug.Log("new: " + newState + " old: " + CurrentState + "   " + _warrior._healPoints);
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }
    }

    public void Stop()
    {
        SetState<WalkState>();
        CurrentState.Exit();
    }

    public void Update()
    {
        if(CurrentState.IsWork)
            CurrentState?.Update();
    }
}
