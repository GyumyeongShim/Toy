using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField] //목표물, 프리펩은 따로하는것으로
    protected GameObject m_target;

    [SerializeField] //목적지
    protected Vector3 m_dstPos;

    [SerializeField] //해당 오브젝트의 종류를 지정
    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.None;

    [SerializeField]
    protected Define.State m_state = Define.State.Idle;
    public virtual Define.State State
    {
        get { return m_state; }
        set
        {
            m_state = value;

            Animator anim = GetComponent<Animator>(); //스테이트를 변경해주고
            //추가적인 조건도 해당 상태에 맞게끔 진행하기
            //현재 FSM으로 만들고 있음, 행동 트리로 구현할 것

            switch (m_state)
            {
                case Define.State.Die:
                    anim.CrossFade("Dead", 0.1f);
                    break;
                case Define.State.Idle:
                    anim.CrossFade("WAIT", 0.1f);
                    break;
                case Define.State.Move:
                    anim.CrossFade("RUN", 0.1f);
                    break;
                case Define.State.Atk:
                    anim.CrossFade("ATTACK", 0.1f, -1, 0);
                    break;
            }
        }
    }
    
    private void Start()
    {
        Init();
    }

    void Update()
    {
        switch (State)
        {
            case Define.State.Idle:
                UpdateIdle();
                break;

            case Define.State.Move:
                UpdateMove();
                break;

            case Define.State.Atk:
                UpdateAtk();
                break;

            case Define.State.Hit:
                UpdateHit();
                break;

            case Define.State.Die:
                UpdateDie();
                break;
        }
    }

    public abstract void Init();

    protected virtual void UpdateIdle() { }
    protected virtual void UpdateMove() { }
    protected virtual void UpdateAtk() { }
    protected virtual void UpdateHit() { }
    protected virtual void UpdateDie() { }
}
