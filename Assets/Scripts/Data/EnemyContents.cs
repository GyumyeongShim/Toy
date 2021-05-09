using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat
{
    //엑셀을 Json으로 받아오기를 구현된 사이트를 통해서 받아오기?
    //해당 이름들이 json과 동일해야함, 순서도 맞출것
    public string Name; //프리펩에서 불러올 이름, 해당값으로 불러오기
    public string Area; //지역에 따라서 달라지기
    public int Level;
    public int Hp;
    public int Atk;
    public int Exp; //
    public int EnemyID;
}

public class EnemyStatData : ILoader<int, EnemyStat>
{
    public List<EnemyStat> m_listEnemyStat = new List<EnemyStat>();

    public Dictionary<int, EnemyStat> MakeDictionary()
    {
        Dictionary<int, EnemyStat> m_dicEnemyStat = new Dictionary<int, EnemyStat>();

        foreach (EnemyStat EnemyStat in m_listEnemyStat)
            m_dicEnemyStat.Add(EnemyStat.EnemyID, EnemyStat);

        return m_dicEnemyStat;
    }
}
