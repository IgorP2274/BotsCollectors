using UnityEngine;

public class DistanceToFlagTransition :  Transition
{
    [SerializeField] private float _transitionRange;

    private Flag _flag;

    private void Start()
    {
        _flag = null;
        Target.TryGetComponent<Flag>(out Flag flag);
        _flag = flag;
    }

    private void Update()
{
        if (_flag != null) 
        {
            if (Vector3.Distance(transform.position, WorkStation.transform.position) <= _transitionRange)
                NeedTransit = true;
        }
}
}
