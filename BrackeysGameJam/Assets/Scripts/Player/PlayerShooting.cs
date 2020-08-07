using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Transform m_firePoint;
    private GameObject m_bulletPrefab;
    [Range(1f, 50f)]
    [SerializeField]
    private float m_bulletForce = 20f;
    [SerializeField]
    [Range(0.001f, 20f)]
    private float m_fireRate;
    private bool m_isMidShot;
    AudioSource m_audioSource;
    AudioClip m_shootSound;
    private void Awake()
    {
        m_bulletPrefab = Resources.Load<GameObject>("Prefabs/RedBullet");
        m_shootSound = Resources.Load<AudioClip>("SFX/Effects/shoot");
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !m_isMidShot && GameManager.Instance.GetAmmo() > 0)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        m_isMidShot = true;
        StartCoroutine(ShootLight());
        m_audioSource.clip = m_shootSound;
        m_audioSource.Play();
        GameObject bullet = Instantiate(m_bulletPrefab, m_firePoint.position, m_firePoint.rotation);
        bullet.GetComponent<BulletController>().SetOnStart(m_bulletForce, m_firePoint, 1);
        yield return new WaitForSeconds(1f / m_fireRate);
        m_isMidShot = false;
    }

    private IEnumerator ShootLight()
    {
        PlayerController.Instance.m_shotLight.intensity = 0.5f;
            yield return new WaitForSeconds(.05f);
        PlayerController.Instance.m_shotLight.intensity = 0f;
    }
}
