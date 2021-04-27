using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Child가 Success이면 순서대로 진행. 
// 모두 Success이거나 하나라도 Fail이면 종료.

public class BTSequence : BTNode
{
    public BTSequence(string name, BaseController owner) //생성자
        : base(name, owner)
    {

    }

    public override IEnumerator Invoke(BTNode root)
    {
        for (int i = 0; i < m_listChild.Count; i++)
        {
            yield return m_listChild[i].Invoke(root);

            if (m_listChild[i].m_BTState == eBTState.Fail)
            {
                m_BTState = eBTState.Fail;
                yield break;
            }
        }

        m_BTState = eBTState.Success;
    }
}
