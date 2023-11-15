using UnityEngine;

public class PickUpState : State
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _heightofResourse = 2;

    private void Update()
    {
        if (transform.childCount == 0) 
            Target.SetParent(transform);

        PickUp();
    }

    private void PickUp() =>
        Target.transform.position = Vector3.MoveTowards(Target.position, transform.position + new Vector3(0, _heightofResourse, 0), _speed * Time.deltaTime);
}
