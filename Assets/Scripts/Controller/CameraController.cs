using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseController
{
    [SerializeField]
    private float m_minDst = 3;

    [SerializeField]
    private float m_maxDst = 30;
    private float m_dst; //목표와의 거리

    [SerializeField]
    private float m_wheelSpeed = 500; //마우스 휠

    [SerializeField]
    private float m_xMoveSpeed = 500; //카메라 y축 회전

    private float m_yMoveSpeed = 250; //카메라 x축 회전
    private float m_yMinLimit = 5; //카메라 x축 회전 제한 최소값
    private float m_yMaxLimit = 80; //카메라 x축 회전 제한 최대값

    private float x, y; //마우스 이동방향 값

    public override void Init()
    {
        //목표와 카메라의 위치를 기준으로 dst 초기화
        m_dst = Vector3.Distance(transform.position, base.m_target.transform.position);
        Vector3 angle = transform.eulerAngles;
        x = angle.y;
        y = angle.x;

        //Managers.Input.m_keyAction -= OnMouseMove;
        //Managers.Input.m_keyAction += OnMouseMove;
    }

    private void LateUpdate()
    {
        if (base.m_target == null)
            return;

        //카메라의 위치 갱신
        transform.position = new Vector3(transform.position.x,
            transform.position.y, 
            base.m_target.transform.position.z - 10);
        //transform.position = transform.rotation * new Vector3(0, 0, -m_dst) + base.m_target.transform.position;
    }

    void OnMouseMove()
    {
        if(Input.GetMouseButton(1))
        {
            //마우스 x,y축 움직임 방향 정보
            x += Input.GetAxis("Mouse X") * m_xMoveSpeed * Time.deltaTime;
            y += Input.GetAxis("Mouse Y") * m_yMoveSpeed * Time.deltaTime;
            //오브젝트의 위아래 한계 범위 설정
            y = ClampAngle(y, m_yMinLimit, m_yMaxLimit);
            transform.rotation = Quaternion.Euler(y, x, 0);
        }

        // 마우스 휠 스크롤을 이용해 목표와 카메라의 거리값 조절
        m_dst -= Input.GetAxis("Mouse ScrollWheel") * m_wheelSpeed * Time.deltaTime;
        //거리는 최소,최대 거리를 설정해서 범위 안에서만
        m_dst = Mathf.Clamp(m_dst, m_minDst, m_maxDst);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;

        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
