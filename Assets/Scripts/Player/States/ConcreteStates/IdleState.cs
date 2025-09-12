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
    public override void AnimationBoolEvent(Player.AnimationBoolType boolType, bool value)
    {
        base.AnimationBoolEvent(boolType,value);
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

        float move = player.Input.GetHorizontal();

        if (move != 0 && player.IsGrounded)
        {
            player.StateMachine.ChangeState(player.MoveState);
        }
        AnimationBoolEvent(Player.AnimationBoolType.Move, false);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
