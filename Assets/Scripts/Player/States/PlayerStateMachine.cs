using UnityEngine;

public class PlayerStateMachine
{
    public PlayerStates CurrentPlayerState {  get; set; }

    public void Initialize(PlayerStates startingState)
    {
        CurrentPlayerState = startingState;
        CurrentPlayerState.EnterState();
    }
    public void ChangeState(PlayerStates newState)//burda önce mevcut durumdan çýkýlýyor sonra yeni state baðlanýyor sonra da yeni statei giriþ state yapýlýyor
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = newState;
        CurrentPlayerState.EnterState();
    }
}

