using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    //해당 스크립트는 파괴될 오브젝트에게 부여함
    //그러나 추후에 안쓸것이고 통합되게 관리하려함
    [SerializeField]
    private Vector3 m_destroyPos;

    void LateUpdate()
    {
        if ((m_destroyPos - transform.position).sqrMagnitude < 0.1f)
            Destroy(gameObject); //자기 자신을 파괴한다
    }
}
