using UnityEngine;

public class MoveState : PlayerStates
{
    public float MoveInput;
    public MoveState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    { // Idle → Move
        Transitions.Add(new Transitions(
            player.IdleState,
            () => player.Input.GetHorizontal() == 0 && player.IsGrounded
        ));

        // Idle → Jump
        Transitions.Add(new Transitions(
            player.JumpState,
            () => player.Input.JumpPressed() && player.IsGrounded
        ));
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
        //bool jump = player.Input.JumpPressed();


        //if (MoveInput == 0 && player.IsGrounded && jump == false)
        //{
        //    playerStateMachine.ChangeState(player.IdleState);
        //}
        //else if (player.IsGrounded && jump)
        //{
        //    player.StateMachine.ChangeState(player.JumpState);
        //}
        player.rb.linearVelocity = new Vector2(MoveInput * player.stats.MoveSpeed, player.rb.linearVelocity.y);

        player.MoveObject(player.rb.linearVelocity);
    }
}