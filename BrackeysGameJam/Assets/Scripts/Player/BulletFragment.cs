using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFragment : MonoBehaviour, Rewind
{
    public float m_respawnTime = 2f;
    private float m_lifeTime = 0f;
    public float m_maxLifeTime = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_lifeTime += Time.deltaTime;
        if(m_lifeTime>m_maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    public void RewindTime()
    {
        throw new System.NotImplementedException();
    }

}
