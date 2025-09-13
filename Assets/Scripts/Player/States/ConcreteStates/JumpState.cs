using UnityEngine;

public class JumpState : PlayerStates
{
    public bool jump;
    public JumpState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void AnimationBoolEvent(Player.AnimationBoolType boolType, bool value)
    {
        player.AnimationBoolEvent(boolType, value);
    }
    public override void EnterState()
    {
        base.EnterState();
        AnimationBoolEvent(Player.AnimationBoolType.Jump, true);

        float moveInput = player.Input.GetHorizontal();

        // Apply jump force immediately on enter (assuming we entered due to jump input)
        player.rb.linearVelocity = new Vector2(moveInput * player.stats.MoveSpeed, player.stats.JumpForce);

        player.MoveObject(player.rb.linearVelocity);
    }

    public override void ExitState()
    {
        base.ExitState();
        AnimationBoolEvent(Player.AnimationBoolType.Jump, false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        float moveInput = player.Input.GetHorizontal();

        // Allow air control by updating horizontal velocity
        player.rb.linearVelocity = new Vector2(moveInput * player.stats.MoveSpeed, player.rb.linearVelocity.y);

        player.MoveObject(player.rb.linearVelocity);

        // Check for landing and transition back to ground states
        if (player.IsGrounded)
        {
            if (moveInput == 0)
            {
                playerStateMachine.ChangeState(player.IdleState);
            }
            else
            {
                playerStateMachine.ChangeState(player.MoveState);
            }
        }
    }
}

