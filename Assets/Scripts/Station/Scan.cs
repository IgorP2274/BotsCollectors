using UnityEngine;
using System.Collections;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(Station))]

public class Scan : MonoBehaviour
{
    [SerializeField] private ResourseSpawner _parentResourse;
    [SerializeField] private int _cooldownTime = 2;

    private Station _station;
    private WaitForSeconds _wait;

    public ResourseSpawner ParentResourse => _parentResourse;

    private void Awake() 
    {
        _station = GetComponent<Station>();
        _wait = new WaitForSeconds(_cooldownTime);
    }

    private void Start() =>
        StartCoroutine(ScanResourses());

    public IEnumerator ScanResourses()
    {
        while (true) 
        {
            Resourse resourse = _parentResourse.GetResourseOrNull();

            if (resourse != null)
                _station.AddFindedResourses(resourse);

            yield return _wait;
        }
    }

    public void SetResourseSpawner(ResourseSpawner parentResourse) =>
        _parentResourse = parentResourse;

    public void Restart() 
    {
        StopCoroutine(ScanResourses());
        StartCoroutine(ScanResourses());
    }
}
