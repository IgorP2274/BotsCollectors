using UnityEngine;

public class CreateNewStation : State
{
    [SerializeField] private Station _station;

    private Bot _bot;

    private void Start()
    {
        _bot = GetComponent<Bot>();
    }

    public void CreateStation()
    {
        Station station = Instantiate(_station, Target.position, Quaternion.identity);
        station.AddBot(_bot);
    }
}
