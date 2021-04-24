using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RaycastEvent : UnityEvent<Transform> { }

public class ObjectDetector : MonoBehaviour
{
    [HideInInspector]
    public RaycastEvent m_raycastEvent = new RaycastEvent();
    public Define.MouseEvent m_mouseBtn;

    [SerializeField]
    private LayerMask m_layerMask;
    private Camera m_mainCamera;
    private Ray m_ray;
    private RaycastHit m_hit;

    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.m_mouseAction -= OnMouseEventInMatchCube;
        Managers.Input.m_mouseAction += OnMouseEventInMatchCube;
        //MainCamera 태그가진 오브젝트 찾기, camera 컴포넌트 정보 가져오기
        m_mainCamera = Camera.main;
        //위는 아래와 같음 
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
