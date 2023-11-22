using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Station : MonoBehaviour
{
    [SerializeField] private ResourseSpawner _parentResourse;
    [SerializeField] private Bot _bot;
    [SerializeField] private int _startBotCount;
    [SerializeField] private int _botCost;
    [SerializeField] private int _stationCost;
    [SerializeField] private UnityEvent _takeCristal;

    public int ResourseCount => _resourseCount;

    private Queue<Resourse> _resourseQueue;
    private Queue<Bot> _botQueue;
    private int _resourseCount;

    private void Awake()
    {
        _botQueue = new Queue<Bot>();
        _resourseQueue = new Queue<Resourse>();
        _resourseCount = 0;
    }

    private void Start()
    {
        for (int i = 0; i < _startBotCount; i++)
            CreateBot();
    }

    private void Update()
    {
        if (_resourseQueue.Count == 0) 
            return;

        if (TryGetFreeBot(out Bot bot))
            bot.GetTarget(_resourseQueue.Dequeue().transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Resourse>(out Resourse resourse))
        {
            AddBot(resourse.GetComponentInParent<Bot>());
            resourse.GetComponentInParent<Bot>().GetTarget(null);
            resourse.DestroyResourse();
            _resourseCount++;
            _takeCristal?.Invoke();
        }
    }

    public bool TryGetFreeBot(out Bot bot)
    {
        if (_botQueue.Count == 0) 
        {
            bot = null;
            return false;
        }
        else 
        {
            bot = _botQueue.Dequeue();
            return true;
        }
    }

    public void AddBot(Bot bot) =>
        _botQueue.Enqueue(bot);

    public void ScanResourses()
    {
        Resourse resourse = _parentResourse.GetResourseOrNull();

        if (resourse != null)
            _resourseQueue.Enqueue(resourse);
    }

    public void BayBot()
    {
        if (_resourseCount >= _botCost)
        {
            CreateBot();
            _resourseCount-= _botCost;
            _takeCristal?.Invoke();
        }
    }

    private void CreateBot()
    {
        Bot bot = Instantiate(_bot, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        bot.transform.SetParent(transform);
        bot.GetBase(this);
        _botQueue.Enqueue(bot);
    }
}
