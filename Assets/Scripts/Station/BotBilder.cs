using UnityEngine;

[RequireComponent(typeof(Station))]

public class BotBilder : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private int _startBotCount;

    private Station _station;

    private void Awake() =>
        _station = GetComponent<Station>();

    private void Start()
    {
        for (int i = 0; i < _startBotCount; i++)
            CreateBot();
    }

    public void CreateBot()
    {
        Bot bot = Instantiate(_bot, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        bot.transform.SetParent(transform);
        bot.GetBase(_station);
        _station.AddBot(bot);
    }
}
