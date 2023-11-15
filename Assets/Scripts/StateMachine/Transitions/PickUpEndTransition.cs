using UnityEngine;

public class PickUpEndTransition : Transition
{
    [SerializeField] private int _heightofResourse = 2;

    private void Update()
    {
        if (Target.position == transform.position + new Vector3(0, _heightofResourse, 0)) 
            NeedTransit = true;
    }
}
