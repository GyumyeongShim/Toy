using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//화면끝에서 해당 오브젝트가 존재하고 주기적으로 큐브셋을 방출할 것임
public class CubeSpawner : MonoBehaviour
{
    //현재 스테이지에서 사용 가능한 큐브의 색상 수
    [SerializeField]
    private Color[] m_cubeColors;
    public Color[] CubeColors => m_cubeColors;

    //큐브셋 생성을 위한 변수
    [SerializeField]
    private GameObject m_cubePrefabs; //큐브셋 프리펩

    [SerializeField]
    private Transform m_spawnTransform; //큐브셋 생성 위치

    [SerializeField]
    private float m_spawnTime = 1.0f; //큐브셋 생성 주기
    //좀더 느리게 하고 많은 색상을 쓰거나, 난이도에 따라 색을 줄이고 속도를 올리는 방식 고려할 것

    void Start()
    {
        StartCoroutine("SpawnCubeSet");
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnCubeSet()
    {
        while(true)
        {
            GameObject clone = Instantiate(m_cubePrefabs, m_spawnTransform.position,)
        }
    }
}
