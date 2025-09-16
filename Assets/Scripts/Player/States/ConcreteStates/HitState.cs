using UnityEngine;

public class HitState : PlayerStates
{   
    public HitState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
    public override void AnimationBoolEvent(Player.AnimationBoolType boolType, bool value)
    {
        base.AnimationBoolEvent(boolType,value);
    }
    public override void EnterState()
    {
        base.EnterState();
        AnimationTriggerEvent(Player.AnimationTriggerType.Hit);

    }
    public override void ExitState()
    {
        base.ExitState();
        AnimationBoolEvent(Player.AnimationBoolType.Idle,true);
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
