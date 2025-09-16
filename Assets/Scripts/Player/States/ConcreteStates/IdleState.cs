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
        base.AnimationBoolEvent(boolType, value);
    }

    public override void EnterState()
    {
        base.EnterState();

        AnimationBoolEvent(Player.AnimationBoolType.Idle, true);
        AnimationBoolEvent(Player.AnimationBoolType.Move, false);
        AnimationBoolEvent(Player.AnimationBoolType.Jump, false);
    }
    public override void ExitState()
    {
        base.ExitState();
        AnimationBoolEvent(Player.AnimationBoolType.Idle, false);
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        float MoveInput = player.Input.GetHorizontal();

        AnimationBoolEvent(Player.AnimationBoolType.Move, MoveInput != 0);

        // Ensure no horizontal movement in idle (stop sliding)
        player.rb.linearVelocity = new Vector2(MoveInput * player.stats.MoveSpeed, player.rb.linearVelocity.y);
        player.MoveObject(player.rb.linearVelocity);

    }

}