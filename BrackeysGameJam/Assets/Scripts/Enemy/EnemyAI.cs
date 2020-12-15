using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{
    public float m_radius;
    public LayerMask m_layer;
    public LayerMask m_obstilceMask;
    AIDestinationSetter m_setter;

    private void Start()
    {
        m_setter = GetComponent<AIDestinationSetter>();
        StartCoroutine(LookForPlayer());
    }


    IEnumerator LookForPlayer()
    {
        while (m_setter.target == null)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, m_radius, m_layer);
            if (col != null)
            {
                Vector2 direction = (Vector2)(PlayerController.Instance.transform.position - transform.position).normalized;
                RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, m_radius);
                RaycastHit2D hitInfoObsticle = Physics2D.Raycast(transform.position, direction, m_radius, 1 << LayerMask.NameToLayer("Obsticle"));
                PlayerController player = hitInfo.transform.GetComponent<PlayerController>();

                if (player != null && hitInfoObsticle.collider == null)
                {
                    Debug.DrawRay(transform.position, direction * m_radius);
                    GetComponent<AIDestinationSetter>().target = PlayerController.Instance.transform;
                    GameManager.Instance.ChangeMusicMode();
                    Destroy(GetComponent<EnemyAI>());
                    break;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }
}
