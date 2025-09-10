using UnityEngine;

public class PlayerStates
{
    protected Player player;//a��klama
    protected PlayerStateMachine playerStateMachine;//a��klama

    public PlayerStates(Player player , PlayerStateMachine playerStateMachine)//a��klama
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
    }
    public virtual void EnterState() { }//a��klama
    public virtual void ExitState() { }//a��klama
    public virtual void FrameUpdate() { }//a��klama
    public virtual void PhysicsUpdate() { }//a��klama
    public virtual void AnimationTriggerEvent(Player.AnimationTriggerType triggerType) { }//a��klama
}