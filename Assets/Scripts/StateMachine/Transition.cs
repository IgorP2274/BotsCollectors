using UnityEngine;

[RequireComponent(typeof(Bot))]

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    protected Transform Target { get; private set; }
    protected Station WorkStation { get; private set; }

    protected Flag FlagForBild { get; private set; }

    public void Init()
    { 
        Target = GetComponent<Bot>().Target;
        WorkStation = GetComponent<Bot>().WorkStation;
        FlagForBild = GetComponent<Bot>().Flag;
    }

    public void OffNeedTransit() =>
        NeedTransit = false;
}
