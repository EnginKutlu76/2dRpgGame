using System.Collections.Generic;
using UnityEngine;

public class PlayerStates
{
    public List<Transitions> Transitions = new List<Transitions>();
    protected Player player;//Bu state �zerinde i�lem yapan Player objesini tutar
    protected PlayerStateMachine playerStateMachine;//State makineleri aras�nda ge�i� yapmay� sa�layan referans
    public PlayerStates(Player player, PlayerStateMachine playerStateMachine)//Constructor: State olu�turulurken Player ve StateMachine referanslar�n� al�r
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void EnterState() { }//State'e girildi�inde �al��acak kodlar buraya yaz�l�r
    public virtual void ExitState() { }//State'den ��karken �al��acak kodlar buraya yaz�l�r
    public virtual void FrameUpdate() { }//Frame bazl� update (Input veya animasyon gibi her frame g�ncellenmesi gereken i�ler)
    public virtual void PhysicsUpdate() { }//Physics bazl� update (Rigidbody hareketleri gibi fizik tabanl� i�lemler)
    public virtual void AnimationTriggerEvent(Player.AnimationTriggerType triggerType) { }// Animator'dan gelen trigger eventlerini yakalamak i�in kullan�l�r
    public virtual void AnimationBoolEvent(Player.AnimationBoolType boolType, bool value) { }//Animator'dan gelen bool eventlerini yakalamak i�in kullan�l�r
}