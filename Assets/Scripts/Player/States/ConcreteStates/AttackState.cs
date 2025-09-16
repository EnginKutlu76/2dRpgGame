using UnityEngine;

public class AttackState : PlayerStates
{
    public AttackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
        
    }
    public override void AnimationBoolEvent(Player.AnimationBoolType boolType, bool value)
    {
        player.AnimationBoolEvent(boolType, value);
    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
    public override void EnterState()
    {
        base.EnterState();
        AnimationTriggerEvent(Player.AnimationTriggerType.Attack);
    }
    public override void ExitState()
    {
        base.ExitState();
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
    }

}
