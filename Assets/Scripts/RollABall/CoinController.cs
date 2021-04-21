using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    private StageController m_stageController;

    [SerializeField]
    private GameObject m_coinEffectPrefab;
    private float m_rotateSpeed = 100.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * m_rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //이펙트 생성
        GameObject clone = Instantiate(m_coinEffectPrefab);
        clone.transform.position = transform.position;

        //코인 획득 시 처리, 지금은 스테이지 컨트롤러지만 씬매니저를 통해서 진행하도록 하겠다
        m_stageController.GetCoin();

        //코인 제거
        Destroy(gameObject);
    }
}
