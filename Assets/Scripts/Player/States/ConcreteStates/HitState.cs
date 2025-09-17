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
        if (player.stats.CurHealth <= 0)
        {
            player.StateMachine.ChangeState(player.DeathState);
            return;
        }
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
    public override void OnAnimationEnd(string animationName)
    {
        if (animationName == "Hit")
        {
            if (player.stats.CurHealth > 0)
                player.StateMachine.ChangeState(player.IdleState);
        }
    }
}
