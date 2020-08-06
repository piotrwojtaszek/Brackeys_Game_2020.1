using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindCollider : MonoBehaviour
{
    [SerializeField]
    LayerMask m_rewindMask;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if ((Input.GetMouseButton(1)))
        {
            if ((m_rewindMask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                collision.GetComponent<Bullet>().Rewind();
                collision.GetComponent<Bullet>().m_isRewind = true;
            }
        }
        else
        {
            if ((m_rewindMask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                if (collision.GetComponent<Bullet>().m_isRewind == true)
                {
                    collision.GetComponent<Bullet>().m_isRewind = false;
                    collision.GetComponent<Bullet>().ImpulsForward();
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if ((m_rewindMask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            if (collision.GetComponent<Bullet>().m_isRewind == true)
            {
                collision.GetComponent<Bullet>().m_isRewind = false;
                collision.GetComponent<Bullet>().ImpulsForward();
            }
        }
    }
}
