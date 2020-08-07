using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRewindMode : MonoBehaviour
{
    TextMeshProUGUI m_text;
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = GameManager.Instance.GetRewindMode().ToString();
    }
}
