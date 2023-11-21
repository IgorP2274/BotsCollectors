using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Station _station;
    [SerializeField] private Bot _bot;

    public void CreateStation()
    {
        Station station = Instantiate(_station, transform.position, Quaternion.identity);
        _bot.GetBase(station);
        _bot.transform.SetParent(_station.transform);
        _bot.GetFlag(null);
        Destroy(gameObject);
    }

}
