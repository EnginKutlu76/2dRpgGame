using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats" )]
public class PlayerStats : ScriptableObject
{
    [Header("Health")]
    public int MaxHealth = 100;

    [Header("Combat")]
    public int BaseDamage = 10;

    [Header("Movement")]
    public float MoveSpeed = 5f;
    public float JumpForce = 12f;
}
