using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : BaseController
{
    [SerializeField]
    private StageMaster m_StageMaster;

    [SerializeField]
    private GameObject m_coinEffectPrefab = null;
    private float m_rotateSpeed = 100.0f;

    public override void Init()
    {
        m_state = Define.State.Move;
    }

    protected override void UpdateMove()
    {
        transform.Rotate(Vector3.right * m_rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //이펙트 생성
        GameObject clone = Managers.Resource.Instantiate(m_coinEffectPrefab.name);
        //GameObject clone = Instantiate(m_coinEffectPrefab);
        clone.transform.position = transform.position;

        //코인 획득 시 처리, 지금은 스테이지 컨트롤러지만 씬매니저를 통해서 진행하도록 하겠다
        m_StageMaster.GetCoin();

        //코인 제거
        Destroy(gameObject);
    }
}
