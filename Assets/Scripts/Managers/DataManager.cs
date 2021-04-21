using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value> //인터페이스를 통해서 상속받으면 해당 메서드를 구현하게끔
{
    Dictionary<Key, Value> MakeDictionary();
}

public class DataManager
{
    //최초에 1번만, 게임 재시작(재도전)하면 stageManager가 읽어온 데이터를 바탕으로 초기화/세팅할것임
    //어떤 데이터가 늘어나도 dictionary를 늘려갑시다
    public Dictionary<int, Stat> m_dicStat { get; private set; } = new Dictionary<int, Stat>();

    public void Init()
    {
        m_dicStat = LoadJson<StatData, int, Stat>("PlayerStat").MakeDictionary();
    }

    Loader LoadJson<Loader,key,value>(string path) where Loader : ILoader<key,value>
    {
        //k,v를 갖는 loader를 반환하는 메서드
        TextAsset txtAsset = Managers.Resource.Load<TextAsset>($"Data/{path}"); //경로안의 텍스트화 되어있는 어셋가져오기
        return JsonUtility.FromJson<Loader>(txtAsset.text); //json파일을 가져오기, 해당 값과 수치를 매핑함
    }

    public void Clear()
    {

    }
}
