using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public float GetHorizontal() => Input.GetAxisRaw("Horizontal");//
    public bool JumpPressed() => Input.GetKeyDown(KeyCode.Space);
}