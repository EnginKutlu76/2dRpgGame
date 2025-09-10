using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats" )]
public class PlayerStats : ScriptableObject
{
    [Header("Health")]
    public int _maxHealth = 100;

    [Header("Combat")]
    public int _baseDamage = 10;

    [Header("Movement")]
    public float _moveSpeed = 5f;
    public float _jumpForce = 12f;
}
