using UnityEngine;
using UnityEngine.Events;

public class Bot : MonoBehaviour
{
    [SerializeField] private Station _station;
    [SerializeField] private Transform _target;
    [SerializeField] private UnityEvent _�hangeTarget;
    [SerializeField] private UnityEvent _�hangeStation;

    public Transform Target => _target;
    public Station WorkStation => _station;

    public void GetTarget(Transform target) 
    {
        _target = target;
        _�hangeTarget?.Invoke();
    }

    public void GetBase(Station station)
    {
        _station = station;
        _�hangeStation?.Invoke();
    }
}
