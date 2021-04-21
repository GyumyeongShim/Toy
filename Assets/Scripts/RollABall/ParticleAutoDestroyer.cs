using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    private ParticleSystem m_particle;

    void Start()
    {
        m_particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
