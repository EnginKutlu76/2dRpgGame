using UnityEngine;

public class IdleState : PlayerStates
{
    public IdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    { // Idle → Move
        Transitions.Add(new Transitions(
            player.MoveState,
            () => player.Input.GetHorizontal() != 0 && player.IsGrounded
        ));

        // Idle → Jump
        Transitions.Add(new Transitions(
            player.JumpState,
            () => player.Input.JumpPressed() && player.IsGrounded
        ));
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
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();

        //float move = player.Input.GetHorizontal();
        //bool jump = player.Input.JumpPressed();
        //if (move != 0 && player.IsGrounded)
        //{
        //    player.StateMachine.ChangeState(player.MoveState);
        //}
        //else if (player.IsGrounded && jump)
        //{
        //    player.StateMachine.ChangeState(player.JumpState);
        //}

        AnimationBoolEvent(Player.AnimationBoolType.Move, false);
        AnimationBoolEvent(Player.AnimationBoolType.Jump, false);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // Ensure no horizontal movement in idle (stop sliding)
        player.rb.linearVelocity = new Vector2(0f, player.rb.linearVelocity.y);
        player.MoveObject(player.rb.linearVelocity);
    }

}