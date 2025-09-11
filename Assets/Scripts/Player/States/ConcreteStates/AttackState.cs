using UnityEngine;

public class AttackState : PlayerStates
{
    //deðerler


    //açýklama
    public AttackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
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
   //     player.MoveObject(Vector3.zero);

        /*Object pooling ile  mermi fýrlatma kodu tarafý*/
    
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
