using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public bool AttackPressed() => Input.GetKeyDown(KeyCode.E);
    public float GetHorizontal() => Input.GetAxisRaw("Horizontal");//
    public bool JumpPressed() => Input.GetKeyDown(KeyCode.Space);
}