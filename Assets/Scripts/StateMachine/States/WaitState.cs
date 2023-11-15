public class WaitState : State
{
    public void SetTarget() 
    { 
        Target = GetComponent<Bot>().Target;
        InitTarget();
    }
}
