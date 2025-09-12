using UnityEngine;

public class MoveState : PlayerStates
{
    public float MoveInput;
    public MoveState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }
    public override void AnimationBoolEvent(Player.AnimationBoolType boolType, bool value)
    {
        player.AnimationBoolEvent(boolType, value);
    }
    public override void EnterState()
    {
        base.EnterState();
        AnimationBoolEvent(Player.AnimationBoolType.Move, true);
    }
    public override void ExitState()
    {
        base.ExitState();
        AnimationBoolEvent(Player.AnimationBoolType.Move, false);
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        MoveInput = player.Input.GetHorizontal();

        AnimationBoolEvent(Player.AnimationBoolType.Move, MoveInput != 0);

        
        if (MoveInput == 0  && player.IsGrounded)  // IsGrounded() implement et eðer yoksa
        {
            playerStateMachine.ChangeState(player.IdleState);
        }

        // Velocity'yi fizik adýmý içinde uygula – bu hareketi düzeltir
        player.rb.linearVelocity = new Vector2(MoveInput * player.stats.MoveSpeed, player.rb.linearVelocity.y);

        // Velocity'yi ayarladýktan sonra flip kontrolünü çaðýr
        player.MoveObject(player.rb.linearVelocity);
    }
}