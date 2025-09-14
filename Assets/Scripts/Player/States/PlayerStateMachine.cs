using UnityEngine;

public class PlayerStateMachine
{
    public PlayerStates CurrentPlayerState { get; set; }
    public void LogicUpdate()
    {
        if (CurrentPlayerState == null)
        {
            Debug.LogError("CurrentPlayerState is null in LogicUpdate!");
            return;
        }

        foreach (var transition in CurrentPlayerState.Transitions)
        {
            if (transition.ConditionMet())
            {
                ChangeState(transition.TargetState);
                break;
            }
        }

        CurrentPlayerState.FrameUpdate();
    }
    public void Initialize(PlayerStates startingState)
    {
        CurrentPlayerState = startingState;
        CurrentPlayerState.EnterState();
    }
    public void ChangeState(PlayerStates newState)//burda �nce mevcut durumdan ��k�l�yor sonra yeni state ba�lan�yor sonra da yeni statei giri� state yap�l�yor
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = newState;
        CurrentPlayerState.EnterState();
    }
}
