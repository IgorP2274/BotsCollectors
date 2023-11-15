using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseSpawner : MonoBehaviour
{
    [SerializeField] private Resourse _resourse;
    [SerializeField] private int _respawnTime;
    [SerializeField] private int _respawnRadius;
    [SerializeField] private int _respawnCount;

    private Queue<Resourse> _resourseQueue;
    private WaitForSeconds _wait;

    private void Awake() 
    {
        _wait = new WaitForSeconds(_respawnTime);
        _resourseQueue = new Queue<Resourse>();
    }

    private void Start() =>
        StartCoroutine(Create());

    public Resourse GetResourseOrNull() 
    {
        if (_resourseQueue.TryDequeue(out Resourse resourse)) 
            return resourse;
        else
            return null;
    }

    private void CreateResourse()
    {
        Resourse resourse = Instantiate(_resourse, GetPosition(), Quaternion.identity);
        resourse.transform.SetParent(gameObject.transform);
        _resourseQueue.Enqueue(resourse);
    }

    private Vector3 GetPosition() =>
        new Vector3(Random.Range(-_respawnRadius, _respawnRadius + 1), 0, Random.Range(-_respawnRadius, _respawnRadius + 1));

    public IEnumerator Create()
    {
        for (int i = 0; i < _respawnCount; i++)
        {
            CreateResourse();
            yield return _wait;
        }
    }
}
