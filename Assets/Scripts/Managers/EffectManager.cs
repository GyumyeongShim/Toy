using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ResourceManager->PoolManager->EffectManager
public class EffectManager
{
    public enum EffectType
    {
        Hit,
        CriticalHit,
        DeadlyHit,
        None
    }

    public enum ParticleType
    {
        Active,
        DeActive,
        None
    }
    public void Init()
    {
        GameObject root = GameObject.Find("@Effect");
        if (root == null)
        {
            root = new GameObject { name = "@Effect" };
            Object.DontDestroyOnLoad(root);
        }
        //Data에서 만들 이펙트목록(컨테이너)를 가져온다
        //Managers.Data.
        //이펙트목록을 통해 최소한으로 이펙트를 만든다
        //Managers.Data.m_dicStat.TryGetValue(이펙트테이블,);

        //Managers.Pool.GetPools
    }

    public void Play()
    {

    }

    public void Stop()
    {

    }

    public void StopAll()
    {

    }

    public void GetEffect()
    {

    }

    public void GetParticle()
    {

    }

    public void Clear()
    {

    }
}
