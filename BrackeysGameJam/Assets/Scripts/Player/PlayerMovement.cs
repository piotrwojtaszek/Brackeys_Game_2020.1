using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private Vector2 m_input;
    private Vector2 m_mousePos;
    [SerializeField]
    private float m_speed = 1f;
    [SerializeField]
    private float m_sprintSpeed=1f;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        m_input.x = Input.GetAxis("Horizontal");
        m_input.y = Input.GetAxis("Vertical");
        m_rb.velocity = m_input * m_speed;

        m_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {


        Vector2 lookDir = m_mousePos - m_rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        m_rb.rotation = angle;
    }
}
