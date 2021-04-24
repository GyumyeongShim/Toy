using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelecter : MonoBehaviour
{
    private ObjectDetector m_objectDetector;
    // Start is called before the first frame update
    void Start()
    {
        m_objectDetector = GetComponent<ObjectDetector>();
        //레이어가 xx인 오브젝트만 선택하도록 레이어 마스크 설정
        m_objectDetector.m_raycastEvent.AddListener(SelectCube);
    }

    public void SelectCube(Transform hit)
    {
        //선택된 오브젝트의 cubecontroller의 변화 함수를 호출
        hit.GetComponent<CubeController>().ChangeColor(m_objectDetector.m_mouseBtn);
    }
}
