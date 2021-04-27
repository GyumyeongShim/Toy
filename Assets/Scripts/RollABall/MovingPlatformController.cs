using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : BaseController
{
    [SerializeField]
    private GameObject[] m_wayPoints = null; //이동가능한 지점

    [SerializeField]
    private float m_waitTime = 0; //wayPoint 도착 후 대기시간

    [SerializeField]
    private float m_speed = 0;
    private int m_wayPointCount = 0;
    private int m_currentIndex = 0;

    public override void Init()
    {
        m_state = Define.State.Move;
        m_wayPointCount = m_wayPoints.Length;
        transform.position = m_wayPoints[m_currentIndex].transform.position;

        m_currentIndex++;

        StartCoroutine("MoveTo");
    }

    private IEnumerator MoveTo()
    {
        while(true)
        {
            //wayPoints[currentState].position까지 이동
            yield return StartCoroutine("Movement");

            //waitTime시간 동안 대기
            yield return new WaitForSeconds(m_waitTime);

            if (m_currentIndex < m_wayPointCount-1)
            {
                m_currentIndex++;
            }
            else
            {
                m_currentIndex = 0; //마지막 wayPoint면 첫번째 wayPoint로 설정
            }
        }
    }

    private IEnumerator Movement()
    {
        while(true)
        {
            Vector3 dir = (m_wayPoints[m_currentIndex].transform.position - transform.position).normalized;
            transform.position += dir * m_speed * Time.deltaTime;

            //목표 위치에 거의 도달하면
            if(Vector3.Distance(transform.position,m_wayPoints[m_currentIndex].transform.position) < 0.1f)
            {
                //현재위치 = 목표위치
                transform.position = m_wayPoints[m_currentIndex].transform.position;
                break;
            }

            yield return null;
        }
    }

    #region Collider 컴포넌트와 관련된 충돌처리
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player") == true) //해당 테그를 가진 오브젝트와 충돌한다면?
        {
            //플레이어 오브젝트를 플랫폼의 자식으로 설정
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player") == true)
        {
            //플레이어 오브젝트를 플랫폼의 자식에서 해제
            collision.transform.SetParent(null);
        }
    }

    #endregion
}
