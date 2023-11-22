using UnityEngine;

[RequireComponent(typeof(Bot))]

public class BildState : State
{
    private Bot _bot;
    private bool _startBild = false;

    private void Start()
    {
        _bot = GetComponent<Bot>();
    }

    private void Update()
    {
        if (_startBild)
            return;

        FlagForBild.CreateStation(_bot);
        _startBild = true;
    }
}
