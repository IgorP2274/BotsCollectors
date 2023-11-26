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
    private Station _selectedStation = null;
    private Bot _bot = null;

    private bool _startBild = false;
    private bool _isStationButtonDown = false;
    private bool _isStationButtonUp = false;

    private void Awake()
    {
        _station = GetComponent<Station>();
        _resourses = GetComponent<ResourseController>();
    }

    private void Update()
    {
        if (_startBild)
            return;

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
            _hit.transform.TryGetComponent(out _selectedStation);

            if (_station == _selectedStation) 
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
            _startBild = true;
            _resourses.SpendResourses(_stationBildCost);
        }
    }
}
