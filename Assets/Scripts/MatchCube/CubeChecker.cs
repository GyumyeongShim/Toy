using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner m_cubeSpawner;
    private CubeController[] m_touchCubes; //터치 가능한 큐브셋의 큐브들

    [SerializeField]
    private StageController m_stageController;

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
        m_touchCubes = GetComponentsInChildren<CubeController>();
        for (int i = 0; i < m_touchCubes.Length; ++i)
        {
            m_touchCubes[i].Init(m_cubeSpawner, this);
        }
    }

    private void Update()
    {
        if (m_stageController.m_isGameOver == true)
            return;

        //맞은 개수 + 틀린 개수가 터치가능한 큐브의 개수와 같을 때
        if(m_correctCnt + m_incorrectCnt == m_touchCubes.Length)
        {
            //다 맞춤 == 성공
            if (m_incorrectCnt == 0)
            {
                Debug.Log("퍼펙트");
                m_stageController.IncreaseScore();
            }
            else
            {
                Debug.Log("틀림");
                m_stageController.GameOver();
            }

            m_correctCnt = 0;
            m_incorrectCnt = 0;
        }
    }
}
