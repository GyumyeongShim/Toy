using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RaycastEvent : UnityEvent<Transform> { }

public class CubeChecker : MonoBehaviour
{
    [SerializeField]
    private StageMaster m_StageMaster = null; //스테이지 클리어 관련으로 필요함

    [SerializeField]
    private CubeSpawner m_cubeSpawner = null;
    private CubeController[] m_touchCubes = null; //터치 가능한 큐브셋의 큐브들

    [HideInInspector]
    public RaycastEvent m_raycastEvent = new RaycastEvent(); //rayCast 이벤트 사용
    public Define.MouseEvent m_mouseBtn; //마우스 클릭 이벤트

    [SerializeField]
    private LayerMask m_layerMask; //충돌 레이어 설정
    private Camera m_mainCamera;
    private Ray m_ray;
    private RaycastHit m_hit;


    private int m_correctCnt = 0;
    private int m_incorrectCnt = 0;

    public int CorrectCnt
    {
        get => m_correctCnt;
        set => m_correctCnt = Mathf.Max(0, value);
    }
    public int IncorrectCnt
    {
        get => m_incorrectCnt;
        set => m_incorrectCnt = Mathf.Max(0, value);
    }

    void Start()
    {
        Managers.Input.m_mouseAction -= OnMouseEventInMatchCube;
        Managers.Input.m_mouseAction += OnMouseEventInMatchCube;
        //MainCamera 태그가진 오브젝트 찾기, camera 컴포넌트 정보 가져오기
        m_mainCamera = Camera.main;
        //위는 아래와 같음 
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        //레이어가 xx인 오브젝트만 선택하도록 레이어 마스크 설정
        m_raycastEvent.AddListener(SelectCube);

        m_touchCubes = GetComponentsInChildren<CubeController>();
        //for (int i = 0; i < m_touchCubes.Length; ++i)
        //{
        //    m_touchCubes[i].Init(m_cubeSpawner, this);
        //}
    }

    public CubeSpawner GetCubeSpawner()
    {
        return m_cubeSpawner;
    }

    public CubeChecker GetCubeChecker()
    {
        return this;
    }

    private void Update()
    {
        if (m_StageMaster.m_isGameOver == true)
            return;

        //맞은 개수 + 틀린 개수가 터치가능한 큐브의 개수와 같을 때
        if(m_correctCnt + m_incorrectCnt == m_touchCubes.Length)
        {
            //다 맞춤 == 성공
            if (m_incorrectCnt == 0)
            {
                Debug.Log("퍼펙트");
                m_StageMaster.IncreaseScore();
            }
            else
            {
                Debug.Log("틀림");
                m_StageMaster.GameOver();
            }

            m_correctCnt = 0;
            m_incorrectCnt = 0;
        }
    }

    public void SelectCube(Transform hit)
    {
        //선택된 오브젝트의 cubecontroller의 변화 함수를 호출
        hit.GetComponent<CubeController>().ChangeColor(m_mouseBtn);
    }

    void OnMouseEventInMatchCube(Define.MouseEvent evt)
    {
        //카메라 - 화면 마우스 광선 생성
        m_ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(m_ray, out m_hit, Mathf.Infinity, m_layerMask))
        {
            switch (evt)
            {
                case Define.MouseEvent.LClick:
                    //충돌한 오브젝트의 transform 정보를 매개변수로 이벤트 호출
                    m_mouseBtn = Define.MouseEvent.LClick;
                    m_raycastEvent.Invoke(m_hit.transform);
                    break;
                case Define.MouseEvent.RClick:
                    m_mouseBtn = Define.MouseEvent.RClick;
                    m_raycastEvent.Invoke(m_hit.transform);
                    break;
            }
        }
    }
}
