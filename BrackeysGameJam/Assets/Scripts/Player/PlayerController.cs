using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public CinemachineVirtualCamera m_baseCamera;
    public CinemachineVirtualCamera m_rewindCamera;

    public float m_rewindTime = 0f;
    public float m_maxRewindTime = 10f;
    public bool m_isRewinding = false;
    public Light2D m_shotLight;
    public Light2D m_spotLight;
    Rigidbody2D m_rb;
    //dac umiejettnosc cofana sie w czasie
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        m_rewindTime = m_maxRewindTime / 2f;
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rewindTime < m_maxRewindTime)
            m_rewindTime += Time.deltaTime * 0.8f;

        ActiveRewind();
        CameraController();
        SpotLightRewindEffect();
        Debug.Log("Predkoscc: " + m_rb.velocity.x);
    }

    private void ActiveRewind()
    {
        if (Input.GetMouseButton(1))
        {
            if (m_isRewinding && m_rewindTime >= 0.1f || !m_isRewinding && m_rewindTime >= .5f)
            {

                m_isRewinding = true;


            }
            else
            {
                m_isRewinding = false;
            }

        }
        else
        {
            m_isRewinding = false;
        }


    }

    private void CameraController()
    {
        if (m_isRewinding)
        {
            if (m_rewindTime > 0f)
                m_rewindTime -= Time.deltaTime;
            m_rewindCamera.Priority = 1000;
            m_rewindCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 10f / (m_rewindTime + 2f);
        }
        else
        {
            m_rewindCamera.Priority = 1;

        }
    }

    private void SpotLightRewindEffect()
    {
        if (m_isRewinding)
        {
            m_spotLight.intensity = Random.Range(.7f, 1.3f);
        }
        else
        {
            m_spotLight.intensity = 1f;
        }
    }
}
