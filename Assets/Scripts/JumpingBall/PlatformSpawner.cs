using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_platformPrefab;

    [SerializeField]
    private int m_spawnPlatformCountAtStart = 8; //게임 시작시 최초에 생성되는 발판 갯수

    [SerializeField]
    private float m_xRange = 4; //발판이 배치될 수 있는 x 위치 범위 (+- m_xRange)

    [SerializeField]
    private float m_zDistance = 5; //발판 사이의 거리
    private int m_platformIndex = 0; //발판 인덱스
    public float ZDst //외부에서 발판 사이의 거리값 Get
    {
        get { return m_zDistance; }
        set { m_zDistance = value; }
    }

    private void Start()
    {
        for (int i = 0; i < m_spawnPlatformCountAtStart; ++i)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        GameObject clone = Managers.Resource.Instantiate(m_platformPrefab.name);
        clone.GetComponent<PlatformController>().Setup(this);
        //발판 위치 초기화
        ResetPlatform(clone.transform);

    }

    public void ResetPlatform(Transform pos, float y = 0)
    {
        m_platformIndex++;
        
        //발판이 배치되는 x위치를 임의로 설정
        float x = Random.Range(-m_xRange, m_xRange);
        //발판이 배치되는 위치 설정(z축은 현재 발판 인덱스 * m_zDistance)
        pos.position = new Vector3(x, y, m_platformIndex * m_zDistance);
    }

}
