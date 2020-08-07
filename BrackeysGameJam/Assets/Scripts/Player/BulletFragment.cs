using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFragment : MonoBehaviour, Rewind
{
    public float m_respawnTime = 2f;
    private float m_currentTime = 0f;
    private float m_lifeTime = 0f;
    public float m_maxLifeTime = 10f;
    private Collider2D m_collider;
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_lifeTime += Time.deltaTime;
        if (m_lifeTime > m_maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    public void RewindTime()
    {
        m_currentTime += Time.deltaTime;
        if (m_currentTime >= m_respawnTime)
        {
            GameObject m_bulletPrefab = Resources.Load<GameObject>("Prefabs/Ammo");
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
