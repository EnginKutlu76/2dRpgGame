using UnityEngine;

public class JumpState : PlayerStates
{
    public bool hasJumped;
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
        // İlk girişte bayrağı işaretle
        hasJumped = true;

        // Animasyon başlat
        AnimationBoolEvent(Player.AnimationBoolType.Jump, true);

        // Zıplamayı bir kere uygula
        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.stats.JumpForce);

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

        //if (player.IsGrounded && hasJumped)
        //{
        //    // Yere indi → Idle’a geç
        //    playerStateMachine.ChangeState(player.IdleState);
        //}
        if (player.Input.JumpPressed() && player.IsGrounded)
        {
            playerStateMachine.ChangeState(player.JumpState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //IsJumped = player.Input.JumpPressed();

        //AnimationBoolEvent(Player.AnimationBoolType.Jump, player.Input.JumpPressed());


        if (!player.IsGrounded)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }

        //player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.stats.JumpForce);

        // Velocity'yi ayarladıktan sonra flip kontrolünü çağır
        player.MoveObject(player.rb.linearVelocity);
    }
}
