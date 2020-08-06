using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
[ExecuteInEditMode]
public class LampController : MonoBehaviour
{
    [SerializeField]
    private Color m_color;
    [SerializeField]
    private float m_rotateSpeed;
    void Start()
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<Light2D>().color = m_color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, m_rotateSpeed);
        float intensity = Mathf.PingPong(Time.time, 1f)+1f;
        foreach (Transform item in transform)
        {
            Light2D light = item.GetComponent<Light2D>();
            light.color = m_color;
            light.intensity = intensity;
        }
    }
}
