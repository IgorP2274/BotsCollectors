using UnityEngine;

public class DistabceBaseTransition : Transition
{
    [SerializeField] private float _transitionRange;

    private void Update()
    {
        if (Vector3.Distance(transform.position, WorkStation.transform.position) <= _transitionRange)
            NeedTransit = true;
    }
}
