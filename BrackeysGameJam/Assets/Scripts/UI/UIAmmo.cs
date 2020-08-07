using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAmmo : MonoBehaviour
{
    TextMeshProUGUI m_tmp;
    // Start is called before the first frame update
    void Start()
    {
        m_tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_tmp.text = GameManager.Instance.GetAmmo().ToString();
    }
}
