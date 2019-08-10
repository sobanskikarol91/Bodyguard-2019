public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState nextState)
    {
        currentState?.Exit();
        currentState = nextState;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState?.Execute();
    }
}