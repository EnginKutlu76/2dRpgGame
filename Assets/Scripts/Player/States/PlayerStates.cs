using System.Collections.Generic;
using UnityEngine;

public class PlayerStates
{
    public List<Transitions> Transitions = new List<Transitions>();

    protected Player player;//Bu state üzerinde işlem yapan Player objesini tutar
    protected PlayerStateMachine playerStateMachine;//State makineleri arasında geçiş yapmayı sağlayan referans
    public PlayerStates(Player player, PlayerStateMachine playerStateMachine)//Constructor: State oluşturulurken Player ve StateMachine referanslarını alır
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void EnterState() { }//State'e girildiğinde çalışacak kodlar buraya yazılır
    public virtual void ExitState() { }//State'den çıkarken çalışacak kodlar buraya yazılır
    public virtual void FrameUpdate() { }//Frame bazlı update (Input veya animasyon gibi her frame güncellenmesi gereken işler)
    public virtual void PhysicsUpdate() { }//Physics bazlı update (Rigidbody hareketleri gibi fizik tabanlı işlemler)
    public virtual void AnimationTriggerEvent(Player.AnimationTriggerType triggerType) { }// Animator'dan gelen trigger eventlerini yakalamak için kullanılır
    public virtual void AnimationBoolEvent(Player.AnimationBoolType boolType, bool value) { }//Animator'dan gelen bool eventlerini yakalamak için kullanılır

    public virtual void OnAnimationEnd(string animationName) { }
}