using UnityEngine;

[RequireComponent(typeof(Station))]

public class Selector : MonoBehaviour
{
    [SerializeField] private Flag _flag;
    [SerializeField] private int _stationBildCost;

    private Flag _flagForBild;
    private bool _isSelectedStation = false;
    private bool _isSelectedFlag = false;
    private RaycastHit _hit;
    private Station _station;
    private Station _selectedStation = null;
    private Bot _bot = null;
    private bool _startBild = false;

    private void Awake()
    {
        _station = GetComponent<Station>();
    }

    private void Update()
    {
        SelectStation();
        CreateFlag();
        StartBild();
    }

    public void SelectStation()
    {
        if (Input.GetMouseButtonDown(0) && _isSelectedStation == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out _hit);
            _hit.transform.TryGetComponent(out _selectedStation);

            if (_station == _selectedStation)
                _isSelectedStation = true;
        }

        if (Input.GetMouseButtonUp(0) && _isSelectedStation)
            _isSelectedFlag = true;
    }

    private void CreateFlag()
    {
        if (_isSelectedFlag == false)
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




                _isSelectedFlag = false;
                _isSelectedStation = false;
            }
        }
    }

    private void StartBild()
    {
        if (_flagForBild == null) 
            return;

        if (_startBild)
            return;

        if (_station.ResourseCount < _stationBildCost)
            return;

        if (_station.TryGetFreeBot(out _bot))
        {
            _bot.GetFlag(_flagForBild);
            _startBild = true;
            _station.SpendResourses(_stationBildCost);
        }   
    }
}
