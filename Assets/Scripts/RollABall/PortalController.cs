using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private Transform m_arrivePoint;
    private AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true) //플레이어와 충돌 여부
        {
            m_audioSource.Play();
            //플레이어 위치 = 도착위치
            other.transform.position = m_arrivePoint.position;
        }
    }

}
