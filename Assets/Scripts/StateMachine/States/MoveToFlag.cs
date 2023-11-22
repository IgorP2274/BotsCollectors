using UnityEngine;

public class MoveToFlag : State
{
    [SerializeField] private float _speed;

    private void Update() =>
        transform.position = Vector3.MoveTowards(transform.position, FlagForBild.transform.position, _speed * Time.deltaTime);
}
