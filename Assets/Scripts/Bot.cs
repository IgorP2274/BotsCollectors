using UnityEngine;
using UnityEngine.Events;

public class Bot : MonoBehaviour
{
    [SerializeField] private Station _station;
    [SerializeField] private Flag _flag;
    [SerializeField] private Transform _target;
    [SerializeField] private UnityEvent _ñhangeTarget;
    [SerializeField] private UnityEvent _ñhangeFlag;
    [SerializeField] private UnityEvent _ñhangeStation;

    public Transform Target => _target;
    public Station WorkStation => _station;

    public Flag Flag => _flag;

    public void GetTarget(Transform target) 
    {
        _target = target;
        _ñhangeTarget?.Invoke();
    }

    public void GetBase(Station station)
    {
        _station = station;
        _ñhangeStation?.Invoke();
    }

    public void GetFlag(Flag flag)
    {
        _flag = flag;
        _ñhangeFlag?.Invoke();
    }
}
