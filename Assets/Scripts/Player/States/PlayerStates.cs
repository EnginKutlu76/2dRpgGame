using UnityEngine;

public class PlayerStates
{
    protected Player player;//açýklama
    protected PlayerStateMachine playerStateMachine;//açýklama

    public PlayerStates(Player player , PlayerStateMachine playerStateMachine)//açýklama
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
    }
    public virtual void EnterState() { }//açýklama
    public virtual void ExitState() { }//açýklama
    public virtual void FrameUpdate() { }//açýklama
    public virtual void PhysicsUpdate() { }//açýklama
    public virtual void AnimationTriggerEvent(Player.AnimationTriggerType triggerType) { }//açýklama
}