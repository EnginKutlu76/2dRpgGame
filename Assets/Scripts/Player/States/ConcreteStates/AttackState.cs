using UnityEngine;

public class AttackState : PlayerStates
{
    //de�erler


    //a��klama
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

        /*Object pooling ile  mermi f�rlatma kodu taraf�*/
    
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
