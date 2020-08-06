using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewind : MonoBehaviour
{
    Image m_tmp;
    // Start is called before the first frame update
    void Start()
    {
        m_tmp = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        m_tmp.fillAmount = PlayerController.Instance.m_rewindTime / PlayerController.Instance.m_maxRewindTime;
    }
}
