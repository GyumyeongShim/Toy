using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRoot : BTNode
{
    public BTRoot(string name, BaseController owner) 
        : base(name, owner)
    {

    }

    public class RandomValue
    {
        public int Value { get; set; } = 0;
        public int Check { get; set; } = 0;
    }

    public RandomValue RandomValue1 = new RandomValue();
    public RandomValue RandomValue2 = new RandomValue();
    public RandomValue RandomValue3 = new RandomValue();
    public RandomValue RandomValue4 = new RandomValue();
    public RandomValue RandomValue5 = new RandomValue();

    private int mEndInvokeCount = 0;

    public void InitRandomValues()
    {
        RandomValue1.Value = UnityEngine.Random.Range(1, 101);
        RandomValue1.Check = 0;

        RandomValue2.Value = UnityEngine.Random.Range(1, 101);
        RandomValue2.Check = 0;

        RandomValue3.Value = UnityEngine.Random.Range(1, 101);
        RandomValue3.Check = 0;

        RandomValue4.Value = UnityEngine.Random.Range(1, 101);
        RandomValue4.Check = 0;

        RandomValue5.Value = UnityEngine.Random.Range(1, 101);
        RandomValue5.Check = 0;
    }

    public override IEnumerator Invoke(BTNode root)
    {
        //mEndInvokeCount = 0;

        //while (m_owner.GetObj().activeSelf == true)
        //{
        //    if (mEndInvokeCount == 0)
        //    {
        //        InitRandomValues();
        //    }

        //    yield return m_listChild[mEndInvokeCount].Invoke(root);

        //    ++mEndInvokeCount;
        //    if (mEndInvokeCount >= m_listChild.Count)
        //    {
        //        mEndInvokeCount = 0;
        //    }
        //}
        yield return null; //임시로 걍 반환
    }

    public IEnumerator UpdateTimer()
    {
        while (true)
        {
            yield return null;
        }
    }
}
