public interface ICondition
{
    bool Evaluate();
}

public class IsGroundedCondition : ICondition
{
    private Player player;
    public IsGroundedCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.IsGrounded;
}

public class HasMoveInputCondition : ICondition
{
    private Player player;
    public HasMoveInputCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.Input.GetHorizontal() != 0;
}

public class JumpPressedCondition : ICondition
{
    private Player player;
    public JumpPressedCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.Input.JumpPressed();
}
public class HasNoMoveInputCondition : ICondition
{
    private Player player;
    public HasNoMoveInputCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.Input.GetHorizontal() == 0;
}
public class AttackPressedCondition : ICondition
{
    private Player player;
    public AttackPressedCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.Input.AttackPressed();
}
public class HasDamagedCondition : ICondition
{
    private Player player;
    public HasDamagedCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.HasTakenDamage;
}
public class HasHealthCondition : ICondition
{
    private Player player;
    public HasHealthCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.stats.CurHealth > 0;
}
public class HasNoHealthCondition : ICondition
{
    private Player player;
    public HasNoHealthCondition(Player player) { this.player = player; }
    public bool Evaluate() => player.stats.CurHealth <= 0;
}


