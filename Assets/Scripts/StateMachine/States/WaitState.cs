public class WaitState : State
{
    public void SetTarget() 
    { 
        Target = GetComponent<Bot>().Target;
        InitTarget();
    }

    public void SetFlag()
    {
        FlagForBild = GetComponent<Bot>().Flag;
        InitTarget();
    }
}
