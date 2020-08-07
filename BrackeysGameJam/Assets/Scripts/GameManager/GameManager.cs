using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum RewindMode
    {
        bullets,
        player
    }
    [SerializeField]
    private int m_ammo = 10;
    private RewindMode m_rewindMode = RewindMode.bullets;
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
                m_rewindMode = RewindMode.player;
                break;
            case RewindMode.player:
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
}
