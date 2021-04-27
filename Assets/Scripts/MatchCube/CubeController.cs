using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : BaseController
{
    //내부의 큐브들이 이것을 1개씩 갖는다
    private CubeSpawner m_cubeSpawner;
    private CubeChecker m_cubeChecker;
    private MeshRenderer m_meshRenderer;
    private int m_colorIndex;

    public override void Init()
    {
        m_cubeChecker = this.GetComponentInParent<CubeChecker>().GetCubeChecker();
        m_cubeSpawner = this.GetComponentInParent<CubeChecker>().GetCubeSpawner();
        //m_cubeChecker = GetComponent<CubeChecker>().GetCubeChecker();
        //m_cubeSpawner = GetComponent<CubeChecker>().GetCubeSpawner();

        m_meshRenderer = GetComponent<MeshRenderer>();
        m_meshRenderer.material.color = m_cubeSpawner.CubeColors[0];
        m_colorIndex = 0;
    }

    public void Init(CubeSpawner cubeSpawner, CubeChecker cubechecker)
    {
        m_cubeSpawner = cubeSpawner;
        m_cubeChecker = cubechecker;
    }

    public void ChangeColor(Define.MouseEvent mousebtn)
    {
        switch (mousebtn)
        {
            //다음 큐브 색상으로 인덱스를 변경
            case Define.MouseEvent.LClick: //증가
                {
                    m_colorIndex++;
                    if (m_colorIndex > m_cubeSpawner.CubeColors.Length - 1) // 0,1,2  0,1,2
                        m_colorIndex = m_cubeSpawner.CubeColors.Length - 1;
                }
                break;

            case Define.MouseEvent.RClick: //감소
                {
                    m_colorIndex--;
                    if (m_colorIndex <= 0)
                        m_colorIndex = 0;
                }
                break;
        }

        //if (m_colorIndex < m_cubeSpawner.CubeColors.Length - 1)
        //{
        //    m_colorIndex++;
        //}
        //else
        //    m_colorIndex = 0;

        //실제 큐브 색상 변경
        m_meshRenderer.material.color = m_cubeSpawner.CubeColors[m_colorIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer renderer = other.GetComponent<MeshRenderer>();
        //둘이 같은 색상인 경우
        if (m_meshRenderer.material.color == renderer.material.color)
            m_cubeChecker.CorrectCnt++;
        else
            m_cubeChecker.IncorrectCnt++;
    }

}
