using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Child가 Fail이면 순서대로 진행.
// 모두 Fail이거나 하나라도 Success이면 종료

public class BTSelector : BTNode
{
    public BTSelector(string name, BaseController owner)
        : base(name, owner)
    {

    }

    public override IEnumerator Invoke(BTNode root)
    {
        for (int i = 0; i < m_listChild.Count; i++)
        {
            yield return m_listChild[i].Invoke(root);

            if (m_listChild[i].m_BTState == eBTState.Success)
            {
                m_BTState = eBTState.Success;
                yield break;
            }
        }

        m_BTState = eBTState.Fail;
    }
}
