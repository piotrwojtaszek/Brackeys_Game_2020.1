using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private LayerMask m_collisionMask;
    [SerializeField]
    private LayerMask m_ignoreMask;
    [Range(1f, 30f)]
    [SerializeField]
    private float m_lifetime = 2f;
    private float m_currentLifetime = 0f;
    private Rigidbody2D m_rb;
    [SerializeField]
    private float m_speed;
    public Transform m_collisionChecker;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (m_currentLifetime >= m_lifetime)
        {
            Destroy(gameObject);
        }
        else
        {
            m_currentLifetime += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(m_collisionChecker.position, GetVectorFromAngle(m_rb.rotation + 90f), 0.1f,m_collisionMask);
        Debug.DrawRay(m_collisionChecker.position, GetVectorFromAngle(m_rb.rotation+90f)*0.1f, Color.red);
        if (raycastHit2D.collider)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void Rewind(Vector3 origin)
    {
        float step = m_speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, origin, step);

        if (Vector3.Distance(transform.position, origin) < 0.3f)
        {
            Destroy(gameObject);
            Debug.Log("rewind_End");
        }
        
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
