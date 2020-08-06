using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public float m_currentHealth;
    public float m_maxHealth;

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual void OnDamage() { }
    public virtual void ReciveDamage(float damage)
    {
        m_currentHealth -= damage;
        if(m_currentHealth<=0f)
        {
            Die();
        }
    }


}
