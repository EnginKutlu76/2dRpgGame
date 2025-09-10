using UnityEngine;

public class IdleState : PlayerStates
{
    public IdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
    public override void EnterState()
    {
        base.EnterState();
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        player.StateMachine.ChangeState(player.IdleState);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
