using System;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    public StateEvent OnStateChange;
    
    public State CurrentState { get; private set; }

    private void Awake()
    {
        OnStateChange = new StateEvent();
        CurrentState = new State();
    }

    public void UpdateState(State state)
    {
        OnStateChange.Invoke(state);
        CurrentState = state;
    }
    
    public void UpdateState(Action<State> func)
    {
        func(CurrentState);
        OnStateChange.Invoke(CurrentState);
    }

}

[Serializable] public class StateEvent : UnityEvent<State> {}

public class State
{
    
    public int p1score;
    public int p2score;
    
    public int p1wins;
    public int p2wins;

    public int p1touch;
    public int p2touch;

}
