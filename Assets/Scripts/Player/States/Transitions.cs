using UnityEngine;
public class Transitions 
{
    public PlayerStates TargetState;      // where to go
    public System.Func<bool> Condition;   // when to go

    public Transitions(PlayerStates targetState, System.Func<bool> condition)
    {
        TargetState = targetState;
        Condition = condition;
    }

    public bool ConditionMet()
    {
        return Condition.Invoke();
    }
}
