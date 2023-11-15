using UnityEngine;

public class UnloadState : State
{
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        if (transform.childCount > 0)
        Upload(transform.GetChild(0));
    }

    private void Upload(Transform resourse)
    {
        Target.position = Vector3.MoveTowards(Target.position, WorkStation.transform.position, _speed * Time.deltaTime);
    }
}
