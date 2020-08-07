using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyPS : MonoBehaviour
{
    ParticleSystem m_ps;
    // Start is called before the first frame update
    void Start()
    {
        m_ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ps)
        {
            if (!m_ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
