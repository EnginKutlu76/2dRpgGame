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

