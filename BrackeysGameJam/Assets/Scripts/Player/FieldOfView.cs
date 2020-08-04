using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    Vector3 origin;
    float fov = 100f;
    int rayCount = 50;
    private Rigidbody2D m_rb;
    float angleIncreace;
    float viewDistance = 4.5f;
    public LayerMask m_bulletLayer;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        angleIncreace = fov / rayCount;

        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position+new Vector3(0f, 0.413f);
        float angle = m_rb.rotation+135f;
        if(Input.GetMouseButton(1))
        {
            for (int i = 0; i <= rayCount; i++)
            {
                RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, m_bulletLayer);
                angle -= angleIncreace;
                Debug.DrawRay(origin, GetVectorFromAngle(angle) * viewDistance, Color.red);
                if (raycastHit2D.collider)
                {
                    raycastHit2D.collider.GetComponent<Bullet>().Rewind(origin);
                }
            }
        }

    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }


}
