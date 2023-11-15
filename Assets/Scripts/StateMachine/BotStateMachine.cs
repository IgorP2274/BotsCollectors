using UnityEngine;

[RequireComponent(typeof(Bot))]

public class BotStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    public State Current => _currentState;

    private State _currentState;

    private void Start() =>
        Reset(_startState);

    private void Update()
    {
        if (Current == null)
            return;

        State next = _currentState.GetNextState();

        if (next != null)
            Transit(next);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (Current != null)
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
