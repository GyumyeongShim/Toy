using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : BaseController
{
    private PlatformSpawner m_platformSpawner;
    private Camera m_mainCamera;
    private float m_yMoveTime = 0.5f; //재 배치되는 플랫폼이 내려오는 시간

    public override void Init()
    {

    }

    public void Setup(PlatformSpawner spawner)
    {
        this.m_platformSpawner = spawner;
        m_mainCamera = Camera.main;
    }

    void Update()
    {
        //카메라 뒤로 넘어가서 안보이면 재 배치
        if(m_mainCamera.transform.position.z - transform.position.z > 0)
        {
            //플랫폼 위치 재설정
            m_platformSpawner.ResetPlatform(this.transform);
            //새로 등장할 때는 위에서 떨어지는 효과 적용
            StartCoroutine(MoveY(10,0));
        }
    }

    private IEnumerator MoveY(float start, float end)
    {
        float current = 0;
        float percent = 0;
        float y = 0;

        while(true)
        {
            current += Time.deltaTime;
            percent = current / m_yMoveTime;

            //시간 경과에 따라 오브젝트의 y위치를 바꿔준다
            y = Mathf.Lerp(start, end, percent); //start->end 위치까지 percent만큼 걸려가며 움직임
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            yield return null;
        }
    }
}
