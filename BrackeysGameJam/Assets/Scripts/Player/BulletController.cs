using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        PlayerController.Instance.SubstractAmmo(1);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetOnStart(float speed, Transform direction)
    {
        m_rb.velocity = direction.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<GoodShoot>() != null)
            collision.collider.GetComponent<GoodShoot>().Award();
        Destroy(gameObject);
    }
}
