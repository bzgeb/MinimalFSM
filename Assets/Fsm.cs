using UnityEngine;

public class Fsm
{
    public enum Step
    {
        Enter,
        Update,
        Exit
    }

    public delegate FsmState FsmState(Step step);

    private FsmState _currentState;

    public void Start(FsmState startState)
    {
        TransitionToState(startState);
    }

    public void Update()
    {
        FsmState nextState = _currentState(Step.Update);
        if (nextState != null)
        {
            TransitionToState(nextState);
        }
    }

    private void TransitionToState(FsmState state)
    {
        if (_currentState?.Invoke(Step.Exit) != null)
        {
            Debug.LogWarning("FsmStates returned from Exit are ignored");
        }

        _currentState = state;
        FsmState nextState = _currentState?.Invoke(Step.Enter);

        if (nextState != null)
        {
            TransitionToState(nextState);
        }
    }
}