using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float m_damage = 1f;
    private Rigidbody2D m_rb;
    EnemyController m_enemyController;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    public void SetOnStart(float speed, Transform direction, int cost)
    {
        m_rb.velocity = direction.up * speed;
        GameManager.Instance.SubstractAmmo(cost);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<EnemyController>() != null)
            m_enemyController = collision.collider.GetComponent<EnemyController>();

        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (m_enemyController != null)
        {
            m_enemyController.ReciveDamage(m_damage);
        }
    }
}
