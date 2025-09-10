using UnityEngine;

public interface IDamageable 
{
    void Damage(float damageAmount);
    void Die();

    float _maxHealth {  get; set; }
    float _currentHealth {  get; set; }
}
