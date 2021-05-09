using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCoolTime : BTNode
{
    private float m_coolTime = 0.0f;
    private float m_curTime = 0.0f;
    private bool m_start = false;


    public BTCoolTime(string name, BaseController owner) : base(name, owner) { }

    public void Set(float coolTime)
    {
        m_coolTime = coolTime;
        m_curTime = 0.0f;

        m_start = false;
    }

    public override IEnumerator Invoke(BTNode root)
    {
        if (!m_start)
        {
            m_owner.StartCoroutine(UpdateCoolTime());
            m_start = true;
        }

        if (m_curTime >= m_coolTime)
        {
            m_start = false;
            m_curTime = 0.0f;

            m_BTState = eBTState.Success;
        }
        else
            m_BTState = eBTState.Fail;

        yield return null;
    }

    private IEnumerator UpdateCoolTime()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        while (true)
        {
            //m_curTime += m_owner.fixedDeltaTime;
            //if (m_curTime >= m_coolTime)
            //    yield break;

            yield return waitForFixedUpdate;
        }
    }
}
