using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private Queue<Resourse> _resourseQueue;
    private Queue<Bot> _botQueue;

    private void Awake()
    {
        _botQueue = new Queue<Bot>();
        _resourseQueue = new Queue<Resourse>();
    }

    private void Update()
    {
        if (_resourseQueue.Count == 0) 
            return;

        if (TryGetFreeBot(out Bot bot))
            bot.GetTarget(_resourseQueue.Dequeue().transform);
    }

    public bool TryGetFreeBot(out Bot bot)
    {
        if (_botQueue.Count == 0) 
            bot = null;
        else 
            bot = _botQueue.Dequeue();

        return bot != null;
    }

    public void AddBot(Bot bot) =>
        _botQueue.Enqueue(bot);

    public void AddFindedResourses(Resourse resourse) =>
            _resourseQueue.Enqueue(resourse);
}
