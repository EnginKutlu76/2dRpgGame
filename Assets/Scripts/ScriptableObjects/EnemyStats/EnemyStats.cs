using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Stats")]
public class EnemyStats: ScriptableObject
{
    [Header("Health")]
    public  float MaxHealth = 100;
    public float CurHealth;

    [Header("Combat")]
    public float BaseDamage ;

    [Header("Movement")]
    public float MoveSpeed = 5f;
    public float JumpForce = 12f;
}
