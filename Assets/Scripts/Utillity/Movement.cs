using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour //물리가 적용된 움직임을 구현하기 위해 일부러 만든 클래스임
{
    [SerializeField]
    private float m_speed; //어느 게임에서나 사용함
    private Rigidbody m_rigid;

    [SerializeField]
    private Vector3 m_moveDir = Vector3.zero; //MatchCube 게임에서만 사용할 것

    void Start()
    {
        //해당 스크립트를 가진 오브젝트에게서 특정 컴포넌트가 있는지 확인하고 없다면 추가해준다!
        //아래의 코드는 잘못된 코드임, 임시로 사용하는 코드
        m_rigid = GetComponent<Rigidbody>();
        if (m_rigid == null)
            m_rigid = gameObject.AddComponent<Rigidbody>() as Rigidbody;
    }

    private void Update()
    {
        if (Managers.Scene.GetActiveSceneName() == "MatchCube")
        {
            transform.position += m_moveDir * m_speed * Time.deltaTime;
        }
    }

    public void MoveTo(Vector3 dir, float force = 0)
    {
        if(Managers.Scene.GetActiveSceneName() == "MatchCube")
        {
            m_moveDir = dir;
        }
        else
        {
            Vector3 moveForce = Vector3.zero;

            if (force == 0)
            {
                dir.y = 0;
                moveForce = dir.normalized * m_speed;
            }
            else
            {
                moveForce = dir * force;
            }

            m_rigid.AddForce(moveForce);
        }
    }
}
