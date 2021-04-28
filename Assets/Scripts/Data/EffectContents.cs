using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 이펙트관련 데이터
//해당 데이터에서 이펙트,파티클의 메타데이터를 가져올 것임
//아래는 장비를 그냥 가져옴
//public class EquipmentStat
//{
//    //해당 이름들이 json과 동일해야함
//    //아래는 그냥 예시로 마니 만들어둠
//    //엑셀에서 불러올 장비와 관련된 수치들 EquipmentStat
//    public int itemId;
//    public int minlevel;
//    public int atk;
//    public int enhancefigure;
//    public string meshname;
//    public string effectname;
//}

//public class EquipmentData : ILoader<int, EquipmentStat> //엑셀 수치들을 유니티에서 데이터화시키는 작업
//{
//    public List<EquipmentStat> m_listEquipmentStat = new List<EquipmentStat>();

//    public Dictionary<int, EquipmentStat> MakeDictionary()
//    {
//        Dictionary<int, EquipmentStat> m_dicEquipData = new Dictionary<int, EquipmentStat>(); //임시 사용

//        //Key값으로 아이템id, 나머지는 전부 value
//        foreach (EquipmentStat stat in m_listEquipmentStat)
//            m_dicEquipData.Add(stat.itemId, stat);

//        return m_dicEquipData;
//    }
//}
#endregion
