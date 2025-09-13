using Unity.VisualScripting;
using UnityEngine;

public class PlayerStates
{
    protected Player player;//Bu state üzerinde iþlem yapan Player objesini tutar
    protected PlayerStateMachine playerStateMachine;//State makineleri arasýnda geçiþ yapmayý saðlayan referans
    public PlayerStates(Player player , PlayerStateMachine playerStateMachine)//Constructor: State oluþturulurken Player ve StateMachine referanslarýný alýr
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
    }
    
    public virtual void EnterState() { }//State'e girildiðinde çalýþacak kodlar buraya yazýlýr
    public virtual void ExitState() { }//State'den çýkarken çalýþacak kodlar buraya yazýlýr
    public virtual void FrameUpdate() { }//Frame bazlý update (Input veya animasyon gibi her frame güncellenmesi gereken iþler)
    public virtual void PhysicsUpdate() { }//Physics bazlý update (Rigidbody hareketleri gibi fizik tabanlý iþlemler)
    public virtual void AnimationTriggerEvent(Player.AnimationTriggerType triggerType) { }// Animator'dan gelen trigger eventlerini yakalamak için kullanýlýr
    public virtual void AnimationBoolEvent(Player.AnimationBoolType boolType,bool value) { }//Animator'dan gelen bool eventlerini yakalamak için kullanýlýr
}