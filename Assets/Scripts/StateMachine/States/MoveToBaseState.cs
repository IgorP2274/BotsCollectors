using UnityEngine;

public class MoveToBaseState : State
{
    [SerializeField] private float _speed;

    void Update() =>
        transform.position = Vector3.MoveTowards(transform.position, WorkStation.transform.position, _speed * Time.deltaTime);
}
