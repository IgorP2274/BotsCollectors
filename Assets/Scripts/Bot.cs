using UnityEngine;
using UnityEngine.Events;

public class Bot : MonoBehaviour
{
    [SerializeField] private Station _station;
    [SerializeField] private Flag _flag;
    [SerializeField] private Transform _target;
    [SerializeField] private UnityEvent _�hangeTarget;
    [SerializeField] private UnityEvent _�hangeFlag;
    [SerializeField] private UnityEvent _�hangeStation;

    public Transform Target => _target;
    public Station WorkStation => _station;

    public Flag Flag => _flag;

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

    public void GetFlag(Flag flag)
    {
        _flag = flag;
        _�hangeFlag?.Invoke();
    }
}
