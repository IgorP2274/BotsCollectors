using UnityEngine;

[RequireComponent(typeof(Station))]

public class Scan : MonoBehaviour
{
    [SerializeField] private ResourseSpawner _parentResourse;

    private Station _station;

    private void Awake() =>
        _station = GetComponent<Station>();

    public void ScanResourses()
    {
        Resourse resourse = _parentResourse.GetResourseOrNull();

        if (resourse != null)
            _station.AddFindedResourses(resourse);
    }
}
