using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterBase, Rewind, GoodShoot
{
    //teleportujace sie gowna
    // Start is called before the first frame update
    GameObject m_bulletFragment;
    GameObject m_particle;
    void Start()
    {
        m_currentHealth = m_maxHealth;
        m_bulletFragment = Resources.Load<GameObject>("Prefabs/BulletFragment");
        m_particle = Resources.Load<GameObject>("Prefabs/VFX/EnemyDeath");
        GameManager.Instance.m_allEnemys++;
        GameManager.Instance.m_angryEnemys++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float damage)
    {
        if (m_currentHealth - damage <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            m_currentHealth -= damage;
        }


    }

    public void Award()
    {
        Vector2 instantianePos = (Vector2)transform.position;
        Instantiate(m_bulletFragment, instantianePos, Quaternion.identity);
    }

    public void RewindTime()
    {
        throw new System.NotImplementedException();
    }

    public override void ReciveDamage(float damage)
    {
        base.ReciveDamage(damage);
        Award();
    }

    public override void Die()
    {
        GameManager.Instance.m_allEnemys--;
        GameManager.Instance.m_angryEnemys--;

        Instantiate(m_particle, transform.position, Quaternion.identity);
        GameObject m_bulletPrefab = Resources.Load<GameObject>("Prefabs/Ammo");
        GameObject bullet = Instantiate(m_bulletPrefab, transform.position + new Vector3(0f,0.2f), Quaternion.identity);
        Destroy(gameObject);
    }
}
