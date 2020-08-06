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
    public float m_currentLifetime = 0f;
    private Rigidbody2D m_rb;
    [SerializeField]
    private float m_speed;
    public Transform m_collisionChecker;
    private Vector3 m_origin;
    public bool m_isRewind = false;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_origin = transform.position;
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
        RaycastHit2D raycastHit2D = Physics2D.Raycast(m_collisionChecker.position, GetVectorFromAngle(m_rb.rotation + 90f), 0.1f, m_collisionMask);
        Debug.DrawRay(m_collisionChecker.position, GetVectorFromAngle(m_rb.rotation + 90f) * 0.1f, Color.red);
        if (raycastHit2D.collider)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public void Rewind()
    {

        if (Vector2.Distance(transform.position, m_origin) < 0.15f)
            m_rb.velocity = Vector2.zero;

        m_rb.AddForce((transform.position - m_origin).normalized * -20f);
        if (m_currentLifetime > 0f)
            m_currentLifetime -= Time.deltaTime * 2f;
    }

    public void ImpulsForward()
    {
        m_rb.velocity = transform.up * 8f;
    }
}
