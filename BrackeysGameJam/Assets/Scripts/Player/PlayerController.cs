using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public CinemachineVirtualCamera m_baseCamera;
    public CinemachineVirtualCamera m_rewindCamera;
    [SerializeField]
    private int m_ammo = 10;
    public float m_rewindTime = 10f;
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
        CameraController();
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

    private void CameraController()
    {
        if (Input.GetMouseButton(1))
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
}
