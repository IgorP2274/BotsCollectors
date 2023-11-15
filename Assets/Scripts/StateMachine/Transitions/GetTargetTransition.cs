public class GetTargetTransition : Transition
{
    private void Update()
    {
        if (Target != null)
            NeedTransit = true;
    }
}
