using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerStates CurrentPlayerState { get; set; }

    private Dictionary<PlayerStates, List<Transitions>> transitions
    = new Dictionary<PlayerStates, List<Transitions>>();

    public void ConfigureTransitions(Player player)
    {
        transitions[player.IdleState] = new List<Transitions>()
        {
            new Transitions(player.MoveState, new HasMoveInputCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.HitState, new HasDamagedCondition(player),new HasHealthCondition(player)),
            new Transitions(player.JumpState, new JumpPressedCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.DeathState, new HasDamagedCondition(player),new HasNoHealthCondition(player)),
            new Transitions(player.AttackState, new AttackPressedCondition(player)/*, new IsGroundedCondition(player)*/)
        };

        transitions[player.MoveState] = new List<Transitions>()
        {
            new Transitions(player.IdleState, new HasNoMoveInputCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.JumpState, new JumpPressedCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.HitState, new HasDamagedCondition(player),new HasHealthCondition(player)),
            new Transitions(player.DeathState, new HasDamagedCondition(player),new HasNoHealthCondition(player)),
            new Transitions(player.AttackState, new AttackPressedCondition(player)/*, new IsGroundedCondition(player)*/)
        };
    
        transitions[player.JumpState] = new List<Transitions>()
        {
            new Transitions(player.IdleState, new HasNoMoveInputCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.MoveState, new HasMoveInputCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.HitState, new HasDamagedCondition(player),new HasHealthCondition(player)),
            new Transitions(player.DeathState, new HasDamagedCondition(player),new HasNoHealthCondition(player)),
            new Transitions(player.AttackState, new AttackPressedCondition(player)/*, new IsGroundedCondition(player)*/)
        };
        transitions[player.AttackState] = new List<Transitions>()
        {
            new Transitions(player.IdleState, new HasNoMoveInputCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.JumpState, new JumpPressedCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.HitState, new HasDamagedCondition(player),new HasHealthCondition(player)),
            new Transitions(player.DeathState, new HasDamagedCondition(player),new HasNoHealthCondition(player)),
            new Transitions(player.MoveState, new HasMoveInputCondition(player), new IsGroundedCondition(player))
        };
        transitions[player.HitState] = new List<Transitions>()
        {
            new Transitions(player.IdleState, new HasNoMoveInputCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.JumpState, new JumpPressedCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.AttackState, new AttackPressedCondition(player)/*, new IsGroundedCondition(player)*/),
            new Transitions(player.MoveState, new HasMoveInputCondition(player), new IsGroundedCondition(player)),
            new Transitions(player.DeathState, new HasDamagedCondition(player),new HasNoHealthCondition(player))
        };
        transitions[player.DeathState] = new List<Transitions>();

    }
    public void LogicUpdate()
    {
        if (transitions.ContainsKey(CurrentPlayerState))
        {
            foreach (var transition in transitions[CurrentPlayerState])
            {
                if (transition.CanTransition())
                {
                    ChangeState(transition.TargetState);
                    break;
                }
            }
        }

        CurrentPlayerState.FrameUpdate(); // aktif state'in kendi davranışı
    }

    public void Initialize(PlayerStates startingState)
    {
        CurrentPlayerState = startingState;
        CurrentPlayerState.EnterState();
    }
    public void ChangeState(PlayerStates newState)//burda önce mevcut durumdan çıkılıyor sonra yeni state başlanıyor sonra da yeni statei giriş state yapılıyor
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = newState;
        CurrentPlayerState.EnterState();
    }
}
