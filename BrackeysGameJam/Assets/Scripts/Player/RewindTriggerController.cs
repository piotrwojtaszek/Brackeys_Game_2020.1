using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTriggerController : MonoBehaviour
{
    //dac if(enum) wartosc enuma to to co aktualnie chcemy przewijac i na dole dac switch case
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (PlayerController.Instance.m_isRewinding && GameManager.Instance.GetRewindMode() == GameManager.RewindMode.bullets)
            if (collision.GetComponent<Rewind>() != null)
            {
                if (collision.GetComponent<BulletFragment>() != null)
                {
                    collision.GetComponent<BulletFragment>().RewindTime();
                }
            }
    }
}
