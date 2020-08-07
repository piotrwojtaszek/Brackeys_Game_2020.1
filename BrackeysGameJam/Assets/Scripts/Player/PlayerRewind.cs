using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewind : MonoBehaviour, Rewind
{
    List<Vector3> m_postions;
    public Collider2D m_collider;
    void Start()
    {
        m_postions = new List<Vector3>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (GameManager.Instance.GetRewindMode() == GameManager.RewindMode.bullets && PlayerController.Instance.m_isRewinding)
        {

        }

        if (!PlayerController.Instance.m_isRewinding)
        {

        }
        */
        if (GameManager.Instance.GetRewindMode() == GameManager.RewindMode.player && PlayerController.Instance.m_isRewinding)
            RewindTime();
        else
        {
            Record();
            m_collider.enabled = true;
        }
    }

    void Record()
    {
        if (m_postions.Count > Mathf.Round(2f / Time.fixedDeltaTime))
            m_postions.RemoveAt(m_postions.Count - 1);

        m_postions.Insert(0, transform.position);
    }

    public void RewindTime()
    {
        if (m_postions.Count > 1)
        {
            transform.position = m_postions[0];
            m_postions.RemoveAt(0);
            m_postions.RemoveAt(0);
            m_collider.enabled = false;
        }

    }
}
