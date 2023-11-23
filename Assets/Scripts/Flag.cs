using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Station _station;

    public void CreateStation(Bot bot)
    {
        Station station = Instantiate(_station, transform.position, Quaternion.identity);
        bot.GetBase(station);
        bot.transform.SetParent(station.transform);
        bot.GetFlag(null);
        Destroy(gameObject);
    }
}
