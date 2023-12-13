using UnityEngine;

public class Entity : MonoBehaviour
{
    protected float currentHealth;
    protected float maxHealth;
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
