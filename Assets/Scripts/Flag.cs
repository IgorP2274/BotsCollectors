using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Station _station;

    public void CreateStation(Bot bot)
    {
        Scan scan = bot.GetComponentInParent<Scan>();
        ResourseSpawner _parentResourse = scan.ParentResourse;

        Station station = Instantiate(_station, transform.position, new Quaternion(0,0,0,0));

        Scan scan2 = station.GetComponent<Scan>();
        scan2.SetResourseSpawner(_parentResourse);
        scan2.Restart();

        bot.GetBase(station);
        bot.transform.SetParent(station.transform);
        bot.GetFlag(null);
        Destroy(gameObject);
    }
}
