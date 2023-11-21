using UnityEngine;

public class DistanceResourseTransition : Transition
{
    [SerializeField] private float _transitionRange;



    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.position) <= _transitionRange)
            NeedTransit = true;
    }
}
