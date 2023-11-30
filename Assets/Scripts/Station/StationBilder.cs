using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Station))]
[RequireComponent(typeof(ResourseController))]

public class StationBilder : MonoBehaviour
{
    [SerializeField] private Flag _flag;
    [SerializeField] private int _stationBildCost;

    private Flag _flagForBild = null;
    private RaycastHit _hit;
    private Station _station;
    private ResourseController _resourses;
    private Bot _bot = null;

    private bool _isStationButtonDown = false;
    private bool _isStationButtonUp = false;

    private void Start()
    {
        _resourses = GetComponent<ResourseController>();
        _station = GetComponent<Station>();
    }

    private void Update()
    {
        SelectStation();
        InstallFlag();
        StartBild(); 
    }

    public void SelectStation()
    {
        if (Input.GetMouseButtonDown(0) && _isStationButtonDown == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out _hit);

            if (_hit.transform == transform) 
                _isStationButtonDown = true;
        }

        if (Input.GetMouseButtonUp(0) && _isStationButtonDown) 
            _isStationButtonUp = true;
    }


    private void InstallFlag()
    {
        if (_isStationButtonUp == false)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                if (_flagForBild == null)
                    _flagForBild = Instantiate(_flag, _hit.point, Quaternion.identity);
                else
                    _flagForBild.transform.position = _hit.point;

                _isStationButtonUp = false;
                _isStationButtonDown = false;

                _resourses.StartBilding();
            }
        }
    }


    private void StartBild()
    {
        if (_flagForBild == null)
            return;

        if (_resourses.ResourseCount < _stationBildCost)
            return;

        if (_station.TryGetFreeBot(out _bot))
        {
            _bot.GetFlag(_flagForBild);
            _resourses.SpendResourses(_stationBildCost);
            _resourses.StopBilding();

            enabled = false;
        }
    }
}
