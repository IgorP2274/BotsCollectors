using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bot))]

public class State : MonoBehaviour
{
    [SerializeField] protected List<Transition> _transitions;

    protected Transform Target { get; set; }
    protected Station WorkStation { get; set; }

    public void Enter()
    {
        if (enabled == false)
        {
            Target = GetComponent<Bot>().Target;
            WorkStation = GetComponent<Bot>().WorkStation;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init();
            }
        }
    }

    public void InitTarget()
    {
        foreach (var transition in _transitions)
            transition.Init();
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions) 
            {
                transition.enabled = false;
                transition.OffNeedTransit();
            }      
        }

        enabled = false;
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
