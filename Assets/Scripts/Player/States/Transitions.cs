using System.Collections.Generic;
using System.Linq;

public class Transitions
{
    public PlayerStates TargetState;
    private List<ICondition> conditions;

    public Transitions(PlayerStates target, params ICondition[] conditions)
    {
        TargetState = target;
        this.conditions = conditions.ToList();
    }

    public bool CanTransition()
    {
        return conditions.All(c => c.Evaluate());
    }
}
