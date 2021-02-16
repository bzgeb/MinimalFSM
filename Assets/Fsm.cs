public class Fsm
{
    public enum Step
    {
        Enter,
        Update,
        Exit
    }

    public delegate State State(Fsm fsm, Step step, State state);

    State _currentState;

    public void Start(State startState)
    {
        TransitionToState(startState);
    }

    public void OnUpdate()
    {
        _currentState.Invoke(this, Step.Update, null);
    }

    private void TransitionToState(State state)
    {
        _currentState?.Invoke(this, Step.Exit, state);
        var oldState = _currentState;
        _currentState = state;
        _currentState.Invoke(this, Step.Enter, oldState);
    }
}
