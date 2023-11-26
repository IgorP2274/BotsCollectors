using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Station))]

public class ResourseController : MonoBehaviour
{
    [SerializeField] private UnityEvent _changedCristalCount;
    [SerializeField] private int _botCost;

    public int ResourseCount => _resourseCount;

    private int _resourseCount;
    private Station _station;
    private BotBilder _botBilder;

    private void Awake()
    {
        _station = GetComponent<Station>();
        _botBilder = GetComponent<BotBilder>();
        _resourseCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Resourse>(out Resourse resourse))
        {
            _station.AddBot(resourse.GetComponentInParent<Bot>());
            resourse.GetComponentInParent<Bot>().GetTarget(null);
            resourse.DestroyResourse();
            _resourseCount++;
            _changedCristalCount?.Invoke();
        }
    }

    public void SpendResourses(int cost)
    {
        _resourseCount -= cost;
        _changedCristalCount?.Invoke();
    }
        
    public void TryBuyBot()
    {
        if (_resourseCount >= _botCost)
        {
            _botBilder.CreateBot();
            _resourseCount -= _botCost;
            _changedCristalCount?.Invoke();
        }
    }
}
