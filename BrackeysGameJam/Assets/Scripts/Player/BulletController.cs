using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float m_damage = 1f;
    private Rigidbody2D m_rb;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetOnStart(float speed, Transform direction,int cost)
    {
        m_rb.velocity = direction.up * speed;
        PlayerController.Instance.SubstractAmmo(cost);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<EnemyController>() != null)
        {
            collision.collider.GetComponent<GoodShoot>().Award();
            collision.collider.GetComponent<EnemyController>().ReciveDamage(m_damage);

        }

        Destroy(gameObject);
    }
}
