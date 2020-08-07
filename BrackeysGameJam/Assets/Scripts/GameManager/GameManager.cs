using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int m_angryEnemys;
    public int m_allEnemys;
    public enum RewindMode
    {
        bullets,
        player
    }
    [SerializeField]
    private int m_ammo = 10;
    private RewindMode m_rewindMode = RewindMode.bullets;
    // set on level change
    private float m_playerHealth = 100f;
    private void Awake()
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
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeRewindMode();
        }
    }

    public void ChangeRewindMode()
    {
        switch(m_rewindMode)
        {
            case RewindMode.bullets:
                PlayerController.Instance.m_rewindCost = 2f;
                m_rewindMode = RewindMode.player;
                break;
            case RewindMode.player:
                PlayerController.Instance.m_rewindCost = 1f;
                m_rewindMode = RewindMode.bullets;
                break;
        }
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
    public RewindMode GetRewindMode()
    {
        return m_rewindMode;
    }

    public void ChangeScene(int index)
    {
        m_playerHealth = PlayerController.Instance.m_currentHealth;

    }

    public void ResetScene()
    {

    }
}
