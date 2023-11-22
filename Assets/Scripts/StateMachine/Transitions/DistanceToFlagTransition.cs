using UnityEngine;

public class DistanceToFlagTransition :  Transition
{
    [SerializeField] private float _transitionRange;

    private void Update()
    {
        if (Vector3.Distance(transform.position, FlagForBild.transform.position) <= _transitionRange)
            NeedTransit = true;
    }
}
