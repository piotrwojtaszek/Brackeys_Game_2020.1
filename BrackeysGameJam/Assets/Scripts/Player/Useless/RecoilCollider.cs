using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilCollider : MonoBehaviour
{
    [SerializeField]
    LayerMask m_rewindMask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((m_rewindMask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            if (collision.GetComponent<Bullet>().m_isRewind || collision.GetComponent<Bullet>().m_currentLifetime > .5f)
            {
                Destroy(collision.gameObject);
                PlayerController.Instance.AddAmmo(1);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((m_rewindMask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            if (collision.GetComponent<Bullet>().m_isRewind || collision.GetComponent<Bullet>().m_currentLifetime > .5f)
            {
                Destroy(collision.gameObject);
                PlayerController.Instance.AddAmmo(1);
            }
        }
    }
}
