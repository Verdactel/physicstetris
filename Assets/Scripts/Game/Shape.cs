using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public bool m_collided = false;
    public bool m_gameover = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Shape")
        {
            m_collided = true;
        }
        if(m_collided == true && collision.gameObject.tag == "Top")
        {
            m_gameover = true;
        }
    }
}
