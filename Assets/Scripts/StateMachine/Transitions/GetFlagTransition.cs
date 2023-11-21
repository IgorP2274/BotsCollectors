public class GetFlagTransition : Transition
{
    private void Update()
    {
        if (FlagForBild != null)
            NeedTransit = true;
    }
}
