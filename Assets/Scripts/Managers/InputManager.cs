using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager
{
    public Action m_keyAction = null;
    public Action<Define.MouseEvent> m_mouseAction = null;

    bool m_pressed = false;
    float m_pressedTime = 0;

    public void Init() { }

    public void OnUpdate()
    {
        if (Input.anyKey && m_keyAction != null)
        {
            m_keyAction.Invoke();
        }

        if(m_mouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                m_mouseAction.Invoke(Define.MouseEvent.LClick);
            }

            if(Input.GetMouseButton(1))
            {
                m_mouseAction.Invoke(Define.MouseEvent.RClick);
            }

            if (Input.GetMouseButton(2))
            {
                m_mouseAction.Invoke(Define.MouseEvent.Wheel);
            }
        }

        //if (m_mouseAction != null)
        //{
        //    if (Input.GetMouseButton(0)) //누르는 중
        //    {
        //        if (m_pressed == false)
        //        {
        //            m_mouseAction.Invoke(Define.MouseEvent.PointerDown);
        //            m_pressedTime = Time.time;
        //        }
        //        m_mouseAction.Invoke(Define.MouseEvent.Press);
        //        m_pressed = true;
        //    }
        //    else
        //    {
        //        if (m_pressed == true)
        //        {
        //            if (Time.time < m_pressedTime + 0.2f)
        //                m_mouseAction.Invoke(Define.MouseEvent.Click);
        //            m_mouseAction.Invoke(Define.MouseEvent.PointerUp);
        //        }
        //        m_pressed = false;
        //        m_pressedTime = 0;
        //    }
        //}
    }

    public void Clear()
    {
        m_keyAction = null;
        m_mouseAction = null;
    }
}
