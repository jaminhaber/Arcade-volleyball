using System;
using UnityEngine.Events;

public class GameState 
{
    public readonly StateUpdateEvent OnStateChange;

    private State lastState;
    public readonly State CurrentState;

    public GameState()
    {
        OnStateChange = new StateUpdateEvent();
        CurrentState = new State();
        lastState = CurrentState;
    }
    
    public void UpdateState(Action<State> func)
    {
        lastState = new State(CurrentState);
        func(CurrentState);
        OnStateChange.Invoke(CurrentState,lastState);
    }

}

[Serializable] public class StateEvent : UnityEvent<State> {}

[Serializable]
public class StateUpdateEvent : UnityEvent<State, State> {}


public class State
{

    public int p1score;
    public int p2score;
    
    public int p1wins;
    public int p2wins;

    public int p1touch;
    public int p2touch;

    public State()
    {
    }

    public State(State s)
    {
        p1score = s.p1score;
        p2score = s.p2score;
        p1wins = s.p1wins;
        p2wins = s.p2wins;
        p1touch = s.p1touch;
        p2touch = s.p2touch;
    }
    
}
