using UnityEngine;

public interface IMoveable 
{
    Rigidbody2D rb { get; set; }
    bool IsFacingRight {  get; set; }
    void MoveObject(Vector2 velocity);
    void CheckForLeftOrRightFacing(Vector2 velocity);

}
