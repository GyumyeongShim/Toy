using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private string m_stageName;

    [Header("RollABall")]
    [SerializeField]
    private float m_minHeight;
    private Movement m_movement;

    [Header("Jumping Ball")]
    [SerializeField]
    private PlatformSpawner m_platformSpawner= null;

    [SerializeField]
    private Transform m_player; //자식으로 있는 sphere 오브젝트

    [SerializeField]
    private float m_xSensitivility = 10.0f; //x축 이동감도

    [SerializeField]
    private float m_moveTime = 1.0f; //y,z 이동 시간

    [SerializeField]
    private float m_minPosY = 0.55f; //y축 이동을 위해 플레이어의 최소 y 위치 설정

    private float m_gravity = -9.81f; //중력
    private int m_platformIdx = 0; //플레이어가 다음으로 이동할 플랫폼 인덱스

    private RaycastHit m_hit; //광선에 부딪힌 오브젝트 정보 저장

    public override void Init()
    {
        m_stageName = Managers.Scene.GetActiveSceneName();

        if(m_stageName == "JumpingBall")
        {
            Managers.Input.m_mouseAction -= OnMouse;
            Managers.Input.m_mouseAction += OnMouse;
        }
        else
        {
            Managers.Input.m_keyAction -= OnKeyboard;
            Managers.Input.m_keyAction += OnKeyboard;
        }

        m_movement = GetComponent<Movement>();

        m_state = Define.State.Idle;

    }

    //private IEnumerator Start()
    //{
    //    //좌클릭 전까지 시작하지 않고 대기
    //    while(true)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            //y,z 이동제어
    //            StartCoroutine("MoveLoop");
    //            break;
    //        }
    //    }

    //    yield return null;
    //}
    private void Update()
    {
        //아래쪽 방향으로 광선을 발사해 광선에 부딪히는 발판 정보를 m_hit에 저장
        Physics.Raycast(transform.position, Vector3.down, out m_hit, 10.0f);
        ChageSceneFallDown();
    }

    void OnKeyboard()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.forward;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            //transform.position += Vector3.forward * Time.deltaTime * m_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }

        m_state = Define.State.Move; //임시로 move상태만
        m_movement.MoveTo(dir);
    }

    void OnMouse(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.LClick)
        {
            StartCoroutine("MoveLoop");
            MoveToX();
        }
        //if (Input.GetMouseButton(0))
        //    MoveToX();
    }

    private IEnumerator MoveLoop()
    {
        while(true)
        {
            m_platformIdx++;

            float current = (m_platformIdx - 1) * m_platformSpawner.ZDst;
            float next = m_platformIdx * m_platformSpawner.ZDst;
            //플레이어의 y,z 위치 제어
            yield return StartCoroutine(MoveToYZ(current, next));
            //플레이어가 나올 플랫폼에 도착했을 떄
            //플레이어의 도착 위치가 플랫폼이면

            if (m_hit.transform != null)
            {
                Debug.Log("Hit");
            }
            else
            {
                Debug.Log("GameOver");
                break;
            }
        }
    }

    private IEnumerator MoveToYZ(float start, float end)
    {
        float current = 0;
        float percent = 0;
        float v0 = -m_gravity; //y 방향의 초기 속도
        float y = 0;
        float z = 0;

        while(true)
        {
            current += Time.deltaTime;
            percent = current / m_moveTime;

            //시간 경과에 따라 오브젝트의 y위치를 바꿔준다
            //포물선 운동 : 시작위치 + 초기속도 * 시간 + 중력 * 시간제곱
            y = m_minPosY + (v0 * percent) + (m_gravity * percent * percent);
            m_player.position = new Vector3(m_player.position.x, y, m_player.position.z);

            //시간 경과에 따라 오브젝트의 z위치를 바꿔준다
            z = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(transform.position.x, transform.position.y, z);

            //y축은 스피어가 포물선 이동하고
            //z축은 플레이어를 관리하는 부모 오브젝트가 직선 이동으로 movetime 시간 동안 이동 후
            //다음 발판에 도착하도록 설정함

            yield return null;
        }

    }

    private void MoveToX()
    {
        float x = 0.0f;
        Vector3 pos = transform.position;

        if(Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                //0.0f~1.0f의 값으로 만들고 -0.5f를 하기 때문에 -0.5~0.5사이로 나옴
                Touch tch = Input.GetTouch(0);
                x = (tch.position.x / Screen.width) - 0.5f;
            }
        }
        else //pc의 경우
        {
            x = (Input.mousePosition.x / Screen.width) - 0.5f;
        }

        x = Mathf.Clamp(x, -0.5f, 0.5f);
        pos.x = Mathf.Lerp(pos.x, x * m_xSensitivility, m_xSensitivility * Time.deltaTime);

        transform.position = pos;
    }

    private void ChageSceneFallDown()
    {
        if (m_stageName == "RollABall" && transform.position.y < m_minHeight)
        {
            Managers.Scene.RestartScene();
        }
    }
}
