using UnityEngine;

public class NewInputSystemAdapter : IPlayerInput
{
    private InputSystem_Actions _actions;

    public NewInputSystemAdapter()
    {
        _actions = new InputSystem_Actions();
        _actions.Enable();
    }

    public float GetHorizontal()
    {
        return _actions.Player.Move.ReadValue<Vector2>().x;
    }

    public bool JumpPressed()
    {
        return _actions.Player.Jump.WasPressedThisFrame();
    }
}
