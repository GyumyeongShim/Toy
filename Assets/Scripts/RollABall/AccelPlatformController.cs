using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelPlatformController : BaseController
{
    [SerializeField]
    private float m_accelForce;

    [SerializeField]
    private Vector3 m_dir;
    private AudioSource m_audioSource;

    public override void Init()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player") == true) //플레이어와의 충돌
        {
            m_audioSource.Play();
            collision.transform.GetComponent<Movement>().MoveTo(m_dir, m_accelForce);
        }
    }

}
