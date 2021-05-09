using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStat
{
    public int level; //해당 이름들이 json과 동일해야함
    public int hp;
    public int atk;
}

public class PlayerStatData : ILoader<int, PlayerStat>
{
    public List<PlayerStat> m_listPlayerStat = new List<PlayerStat>();
    public Dictionary<int, PlayerStat> MakeDictionary()
    {
        Dictionary<int, PlayerStat> m_dicPlayerStat = new Dictionary<int, PlayerStat>(); //임시 사용
        foreach (PlayerStat PlayerStat in m_listPlayerStat)
            m_dicPlayerStat.Add(PlayerStat.level, PlayerStat);

        return m_dicPlayerStat;
    }
}
