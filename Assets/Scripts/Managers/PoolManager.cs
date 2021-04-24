using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    Dictionary<string, List<Pool>> m_dicPool; //stack, queue는 c#에서 무한하다함

    //오리지널이 있으면 사용
    //혹시 풀링된 것이 있다면 사용
    public void Init()
    {
        //미리 이펙트 사운드 등등을 미리 풀링해둘것...
    }

    public void CreatPool(string objname, int cnt = 10)
    {
        if (cnt <= 0)
            return;

        if (CheckHasPool(objname) == true)
        {
            Debug.LogError(objname + "은 이미 존재하는 풀");
            return;
        }

        GameObject go = Managers.Resource.Instantiate(objname);
        if(go == null)
        {
            Debug.LogError(objname + "은 Prefabs에 존재 하지 않음");
            return;
        }

        List<Pool> listObj = new List<Pool>();
        listObj.Capacity = cnt; //사용될 오브젝트 갯수를 미리 할당하기

        for (int i = 0; i < cnt; ++i) //순회하면서 비활성화된 상태로 해당 키값에 value를 넣어줌
        {
            go = Managers.Resource.Instantiate(objname);
            go.name = objname;
            Pool pool = Extension.GetOrAddComponent<Pool>(go);
            pool.Original = go; //원본은 방금 만든 오브젝트
            pool.SetActive(false);
            listObj.Add(pool);
        }

        m_dicPool.Add(objname, listObj);
    }

    bool CheckHasPool(string objname) //해당 풀이 있는지?
    {
        return m_dicPool.ContainsKey(objname);
    }

    public void AddObjToPool(string objname)
    {
        Pool pool = null;

        if (CheckHasPool(objname) == false)
        {
            CreatPool(objname);
            pool = GetPool(objname);
            return;
        }

        GameObject go = Managers.Resource.Instantiate(objname);
        if (go == null)
        {
            Debug.LogError(objname + "은 Prefabs에 존재 하지 않음");
            return;
        }

        pool = Extension.GetOrAddComponent<Pool>(go);
        pool.Original = go;

        //++m_dicPool[objname].Capacity; //1칸 증가하는걸까? 아니면 걍 늘어났으나 1칸만 쓰는걸까?
        m_dicPool[objname].Add(pool);
    }

    public Pool GetPool(string objname) //오브젝트를 줌
    {
        if (CheckHasPool(objname) == false)
        {
            return null;
        }

        Pool pool = m_dicPool[objname].Find(x => x.isActive() == false);
        if(pool == null)
        {
            return null;
        }

        return pool;
    }

    public List<Pool> GetPools(string objname, int cnt) //해당 풀 전체를 주기
    {
        if(CheckHasPool(objname))
        {
            Debug.LogError(objname + "은 없는 pool");
            return null;
        }

        if(cnt > m_dicPool[objname].Count)
        {
            Debug.LogError(objname + "을 보유보다 많은 수를 요청");
            return null;
        }

        List<Pool> listPool = m_dicPool[objname].FindAll(x => x.isActive() == false);
        if (listPool.Count < cnt)
        {
            Debug.LogError(objname + "비활성화된 유닛보다 많이 요청함");
            return null;
        }

        return listPool;
    }

    void ReturnToPool(Pool pool) //오브젝트를 돌려받음
    {
        //오브젝트 비활성화, 반납
        pool.SetActive(false);
    }

    void ReturnAllToPool(string objname) //해당 풀 전체를 돌려받음
    {
        if(CheckHasPool(objname) == false)
        {
            Debug.LogError(objname + "는 없는 풀");
            return;
        }

        for(int i =0; i<m_dicPool[objname].Count;++i)
        {
            ReturnToPool(m_dicPool[objname][i]);
        }
    }

    public void Clear() //싹다 지우기
    {
        foreach(KeyValuePair<string,List<Pool>> kv in m_dicPool)
        {
            for(int i = 0; i<kv.Value.Count;++i)
            {
                GameObject.DestroyImmediate(kv.Value[i].Original);
            }
        }

        m_dicPool.Clear();
    }
}
