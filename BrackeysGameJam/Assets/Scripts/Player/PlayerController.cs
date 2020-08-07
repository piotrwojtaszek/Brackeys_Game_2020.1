using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : CharacterBase
{
    public static PlayerController Instance;
    public CinemachineVirtualCamera m_baseCamera;
    public CinemachineVirtualCamera m_rewindCamera;

    public float m_rewindTime = 0f;
    public float m_maxRewindTime = 14f;
    public bool m_isRewinding = false;
    public Light2D m_shotLight;
    public Light2D m_spotLight;
    public float m_rewindCost = 1f;
    public Rigidbody2D m_rb;
    //dac umiejettnosc cofana sie w czasie
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
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
        RewindTimeSetter();
        ActiveRewind();
        CameraController();
        SpotLightRewindEffect();
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

    void RewindTimeSetter()
    {
        if (m_isRewinding)
        {
            if (m_rewindTime > 0f)
                m_rewindTime -= Time.deltaTime * m_rewindCost;
        }
        else
        {
            if (m_rewindTime < m_maxRewindTime)
                m_rewindTime += Time.deltaTime * 1f;
        }
    }

    private void CameraController()
    {
        if (m_isRewinding)
        {

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
