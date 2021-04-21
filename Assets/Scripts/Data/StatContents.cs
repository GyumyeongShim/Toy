using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region 스텟관련 데이터
public class Stat
{
    public int level; //해당 이름들이 json과 동일해야함
    public int hp;
    public int atk;
}

public class StatData : ILoader<int, Stat>
{
    public List<Stat> m_listStat = new List<Stat>();
    public Dictionary<int, Stat> MakeDictionary()
    {
        Dictionary<int, Stat> m_dicStat = new Dictionary<int, Stat>(); //임시 사용
        foreach (Stat stat in m_listStat)
            m_dicStat.Add(stat.level, stat);

        return m_dicStat;
    }
}
#endregion
