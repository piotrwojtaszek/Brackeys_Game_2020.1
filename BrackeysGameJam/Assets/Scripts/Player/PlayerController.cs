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
    [SerializeField]
    private int m_ammo = 10;
    public float m_rewindTime = 10f;
    public bool m_isRewinding = false;
    public Light2D m_shotLight;
    public Light2D m_spotLight;
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

    }

    // Update is called once per frame
    void Update()
    {
        ActiveRewind();
        CameraController();
        SpotLightRewindEffect();
    }

    public void AddAmmo(int amount)
    {
        m_ammo += amount;
    }
    public void SubstractAmmo(int amount)
    {
        m_ammo -= amount;
    }
    public int GetAmmo()
    {
        return m_ammo;
    }

    private void ActiveRewind()
    {
        if (Input.GetMouseButton(1))
        {
            m_isRewinding = true;
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
            if (m_rewindTime > 0.1f)
                m_rewindTime -= Time.deltaTime;
            m_rewindCamera.Priority = 1000;
            m_rewindCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 10f / (m_rewindTime+2f);
        }
        else
        {
            m_rewindCamera.Priority = 1;
            if (m_rewindTime < 10f)
                m_rewindTime += Time.deltaTime;
        }
    }

    private void SpotLightRewindEffect()
    {
        if(m_isRewinding)
        {
            m_spotLight.intensity = Random.Range(.7f, 1.3f);
        }
        else
        {
            m_spotLight.intensity = 1f;
        }
    }
}
