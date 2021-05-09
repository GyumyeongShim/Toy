using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCondition : BTNode
{
    //private eCompareType m_eCompareType;
    //private eOwnerReferenceValue m_eOwnerRefValue;
    //private object m_value = null;
    //private string m_param = null;

    public BTCondition(string name, BaseController owner) 
        : base(name, owner)
    {

    }

    public override IEnumerator Invoke(BTNode root)
    {
        yield return null;
    }
    //{
    //    m_BTState = eBTState.Fail;

    //    if (m_owner.curHp <= 0.0f || m_eOwnerRefValue == eOwnerReferenceValue.None || m_value == null)// || m_owner.isStopBT == true)
    //    {
    //        yield break;
    //    }

    //    BTRoot btRoot = root as BTRoot;
    //    eActionCommand actionCommand = eActionCommand.None;

    //    float curHp = m_owner.curHp;
    //    float maxHp = m_owner.maxHp;
    //    if (m_owner.parent)
    //    {
    //        curHp = m_owner.parent.curHp;
    //        maxHp = m_owner.parent.maxHp;
    //    }

    //    float curSp = m_owner.curSp;
    //    if (m_owner.parent)
    //    {
    //        curSp = m_owner.parent.curSp;
    //    }

    //    int randHitCount = UnityEngine.Random.Range(5, 10);

    //    UnitCollider targetCollider = null;
    //    switch (m_eOwnerRefValue)
    //    {
    //        case eOwnerReferenceValue.CurHp:
    //            btState = CheckValueType<float>(curHp);
    //            break;

    //        case eOwnerReferenceValue.CurHpPercentage:
    //            btState = CheckValueType<float>((curHp / maxHp) * 100.0f);
    //            break;

    //        case eOwnerReferenceValue.CurSpPercentage:
    //            btState = CheckValueType<float>((curSp / GameInfo.Instance.BattleConfig.USMaxSP) * 100.0f);
    //            break;

    //        case eOwnerReferenceValue.AniSpeed:
    //            btState = CheckValueType<float>(m_owner.aniEvent.aniSpeed);
    //            break;

    //        case eOwnerReferenceValue.HasTarget:
    //            targetCollider = m_owner.GetMainTargetCollider(false);
    //            if (targetCollider)
    //            {
    //                if (targetCollider.Owner.actionSystem.IsCurrentQTEAction() || targetCollider.Owner.actionSystem.IsCurrentUSkillAction()) // QTE나 오의 사용 중엔 공격하지 않는다.
    //                    btState = eBTState.Fail;//m_owner.HasTarget());
    //                else
    //                    btState = eBTState.Success;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(targetCollider != null);
    //                //btState = eBTState.Fail;
    //            }
    //            break;

    //        case eOwnerReferenceValue.HasHitTarget:
    //            btState = CheckBoolType(m_owner.HasHitTarget());
    //            break;

    //        case eOwnerReferenceValue.IsTarget:
    //            btState = CheckObjectType((UnityEngine.Object)m_value);
    //            break;

    //        case eOwnerReferenceValue.InAttackRange:
    //            actionCommand = Utility.GetActionCommandByString(m_param);
    //            btState = CheckBoolType(m_owner.CheckTargetDist(actionCommand));
    //            break;

    //        case eOwnerReferenceValue.IsNoAttack:
    //            btState = CheckBoolType(m_owner.isNoAttack);
    //            break;

    //        case eOwnerReferenceValue.IsReachTarget:
    //            targetCollider = m_owner.GetMainTargetCollider(false);
    //            if (targetCollider == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                float dist = m_owner.GetDistance(targetCollider.Owner);
    //                btState = CheckBoolType(dist <= Utility.SafeParse(m_param));
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsState:
    //            btState = CheckStateType((string)m_value);
    //            break;

    //        case eOwnerReferenceValue.IsAttacking:
    //            if (!m_owner.actionSystem.IsCurrentAnyAttackAction())
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        case eOwnerReferenceValue.HasParts:
    //            EnemyParts enemyParts = m_owner as EnemyParts;
    //            if (enemyParts == null)
    //                btState = eBTState.Fail;
    //            else
    //                btState = CheckBoolType(enemyParts.hasParts);
    //            break;

    //        case eOwnerReferenceValue.HasAction:
    //            if (m_owner.actionSystem.HasAction(Utility.GetActionCommandByString((string)m_value)))
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        /*case eOwnerReferenceValue.NextPatternIndex:
    //            btState = CheckValueType<int>(m_owner.patternIndex);
    //            break;

    //        case eOwnerReferenceValue.NextPatternIndex2:
    //            btState = CheckValueType<int>(m_owner.patternIndex2);
    //            break;*/

    //        case eOwnerReferenceValue.CheckDistance:
    //            targetCollider = m_owner.GetMainTargetCollider(false);
    //            if (targetCollider == null)
    //                btState = eBTState.Fail;
    //            else
    //            {
    //                Vector3 dest = targetCollider.Owner.transform.position;// + Vector3.Normalize(m_owner.transform.position - target.transform.position);
    //                dest.y = m_owner.transform.position.y;

    //                float dist = Vector3.Distance(m_owner.transform.position, dest);
    //                btState = CheckValueType<float>(dist);
    //            }
    //            break;

    //        case eOwnerReferenceValue.CheckCurrentAction:
    //            eActionCommand command = Utility.GetActionCommandByString((string)m_value);
    //            if (m_owner.actionSystem.BeforeActionCommand == command) // 하나의 액션이 끝나야 다음 노드가 실행되므로 이전 액션을 검사해줘야함
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        case eOwnerReferenceValue.GlobalRandomValue1:
    //            btRoot.RandomValue1.Check += (int)m_value;
    //            if (btRoot.RandomValue1.Value <= btRoot.RandomValue1.Check)
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        case eOwnerReferenceValue.GlobalRandomValue2:
    //            btRoot.RandomValue2.Check += (int)m_value;
    //            if (btRoot.RandomValue2.Value <= btRoot.RandomValue2.Check)
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        case eOwnerReferenceValue.GlobalRandomValue3:
    //            btRoot.RandomValue3.Check += (int)m_value;
    //            if (btRoot.RandomValue3.Value <= btRoot.RandomValue3.Check)
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        case eOwnerReferenceValue.GlobalRandomValue4:
    //            btRoot.RandomValue4.Check += (int)m_value;
    //            if (btRoot.RandomValue4.Value <= btRoot.RandomValue4.Check)
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        case eOwnerReferenceValue.GlobalRandomValue5:
    //            btRoot.RandomValue5.Check += (int)m_value;
    //            if (btRoot.RandomValue5.Value <= btRoot.RandomValue5.Check)
    //                btState = eBTState.Success;
    //            else
    //                btState = eBTState.Fail;
    //            break;

    //        case eOwnerReferenceValue.LocalRandomValue:
    //            int random = UnityEngine.Random.Range(1, 101);// (int)(m_value) + 1);
    //            btState = CheckValueType<int>(random);
    //            break;

    //        case eOwnerReferenceValue.IsAttack:
    //            btState = btState = CheckBoolType(m_owner.curSuccessAttack);
    //            if (btState == eBTState.Fail)
    //            {
    //                m_owner.ResetBT();
    //            }
    //            break;

    //        case eOwnerReferenceValue.HasMesh:
    //            if (m_owner.aniEvent.HasMesh((string)m_value))
    //            {
    //                btState = eBTState.Success;
    //            }
    //            else
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            break;

    //        case eOwnerReferenceValue.HasMinion:
    //            Enemy enemy = m_owner as Enemy;
    //            if (enemy == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                if (enemy.ListMinion.Count > 0)
    //                {
    //                    btState = eBTState.Success;
    //                }
    //                else
    //                {
    //                    btState = eBTState.Fail;
    //                }
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsSummoningMinion:
    //            enemy = m_owner as Enemy;
    //            if (enemy == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(enemy.SummoningMinion);
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsAllMinionDead:
    //            enemy = m_owner as Enemy;
    //            if (enemy == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                if (enemy.IsAllMinionDead())
    //                {
    //                    btState = eBTState.Success;
    //                }
    //                else
    //                {
    //                    btState = eBTState.Fail;
    //                }
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsHit:
    //            if (!m_owner.actionSystem.IsCurrentHitAction())
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                ActionHit actionHit = m_owner.actionSystem.GetCurrentAction<ActionHit>();
    //                if (actionHit == null)
    //                {
    //                    btState = eBTState.Fail;
    //                }
    //                else
    //                {
    //                    btState = CheckBoolType(actionHit.State == ActionHit.eState.Normal);
    //                }
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsActionPlaying:
    //            actionCommand = Utility.GetEnumByString<eActionCommand>(m_param);
    //            btState = CheckBoolType(m_owner.actionSystem.IsCurrentAction(actionCommand));
    //            break;

    //        case eOwnerReferenceValue.IsContinuingDash:
    //            Player continuingDashPlayer = m_owner as Player;
    //            if (continuingDashPlayer == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(continuingDashPlayer.ContinuingDash);
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsTargetActionPlaying:
    //            if (m_owner.mainTarget == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                actionCommand = Utility.GetEnumByString<eActionCommand>(m_param);
    //                btState = CheckBoolType(m_owner.mainTarget.actionSystem.IsCurrentAction(actionCommand));
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsSlow:
    //            if (m_owner.aniEvent == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(m_owner.aniEvent.aniSpeed < 1.0f);
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsTargetSlow:
    //            if (m_owner.mainTarget == null || m_owner.aniEvent == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(m_owner.mainTarget.aniEvent.aniSpeed < 1.0f);
    //            }
    //            break;

    //        case eOwnerReferenceValue.HasChargingAttack:
    //        case eOwnerReferenceValue.HasHoldingDefBtnAttack:
    //        case eOwnerReferenceValue.HasRushAttack:
    //        case eOwnerReferenceValue.HasTeleport:
    //        case eOwnerReferenceValue.HasAttackDuringAttack:
    //            string strActionCommand = (m_eOwnerRefValue.ToString().Replace("Has", ""));
    //            eActionCommand hasActionCommand = Utility.GetEnumByString<eActionCommand>(strActionCommand);

    //            ActionSelectSkillBase actionSelectSkill = m_owner.actionSystem.GetAction<ActionSelectSkillBase>(hasActionCommand);
    //            if (actionSelectSkill)
    //            {
    //                btState = CheckBoolType(actionSelectSkill.PossibleToUseInAI() && m_owner.CheckTargetDist(hasActionCommand));
    //            }
    //            else
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsMurasakiChargeComboAttack:
    //            ActionMurasakiComboAttack murasakiComboAttack = m_owner.actionSystem.GetCurrentAction<ActionMurasakiComboAttack>();
    //            if (murasakiComboAttack == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                if (!murasakiComboAttack.IsLastAttack())
    //                {
    //                    btState = eBTState.Success;
    //                }
    //                else
    //                {
    //                    btState = eBTState.Fail;
    //                }
    //            }
    //            break;

    //        case eOwnerReferenceValue.HasActiveWeaponSkill:
    //            Player player = m_owner as Player;
    //            if (player == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(player.HasWeaponActiveSkill() && player.IsActiveWeaponSkill());
    //            }
    //            break;

    //        case eOwnerReferenceValue.HasSupporterActiveSkill:
    //            player = m_owner as Player;
    //            if (player == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(player.boSupporter != null && player.boSupporter.HasActiveSkill() &&
    //                                        World.Instance.UIPlay.sprSupporterCoolTime.fillAmount <= 0.0f);
    //            }
    //            break;

    //        case eOwnerReferenceValue.IsRepeatSkill:
    //            actionSelectSkill = m_owner.actionSystem.GetCurrentAction<ActionSelectSkillBase>();
    //            if (actionSelectSkill == null)
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            else
    //            {
    //                btState = CheckBoolType(actionSelectSkill.IsRepeatSkill);
    //            }
    //            break;

    //        case eOwnerReferenceValue.CheckTimingHoldFrame:
    //            AniEvent.sAniInfo aniInfo = m_owner.aniEvent.GetAniInfo(m_owner.aniEvent.curAniType);
    //            if (aniInfo.timingHoldFrame > 0.0f && m_owner.aniEvent.GetCurrentFrame() >= aniInfo.timingHoldFrame)
    //            {
    //                btState = eBTState.Success;
    //            }
    //            else
    //            {
    //                btState = eBTState.Fail;
    //            }
    //            break;
    //    }
    //}

    //public void Set()
    //{

    //}

    //public void Set(eOwnerReferenceValue reference, object value, eCompareType compareType)
    //{
    //    m_eOwnerRefValue = reference;
    //    m_value = value;
    //    m_eCompareType = compareType;
    //}

    //public void Set(string reference, string value, string compareType, string param)
    //{
    //    int rInt = 0;
    //    float rFloat = 0.0f;

    //    if (value == "OtherObject")
    //        m_value = World.Instance.EnemyMgr.otherObject;
    //    else if (value == "Player")
    //        m_value = World.Instance.Player;
    //    else if (value == "true" || value == "false")
    //        m_value = value == "true" ? true : false;
    //    else if (int.TryParse(value, out rInt) == true)
    //        m_value = rInt;
    //    else if (Utility.SafeTryParse(value, out rFloat) == true)
    //        m_value = rFloat;
    //    else
    //        m_value = value;

    //    m_param = param;

    //    m_eOwnerRefValue = (eOwnerReferenceValue)Enum.Parse(typeof(eOwnerReferenceValue), reference);
    //    if (m_eOwnerRefValue == eOwnerReferenceValue.None)
    //        Debug.LogError(reference + "는 eOwnerReferenceValue가 아닙니다.");

    //    if (!string.IsNullOrEmpty(compareType))
    //    {
    //        m_eCompareType = (eCompareType)Enum.Parse(typeof(eCompareType), compareType);
    //        if (m_eCompareType == eCompareType.None)
    //            Debug.LogError(compareType + "는 eCompareType이 아닙니다.");
    //    }
    //}

    //private eBTState CheckBoolType(bool ownerRefValue)
    //{
    //    if ((m_eCompareType == eCompareType.Equal && ownerRefValue == (bool)m_value) ||
    //        (m_eCompareType == eCompareType.NotEqual && ownerRefValue != (bool)m_value))
    //    {
    //        return eBTState.Success;
    //    }

    //    return eBTState.Fail;
    //}

    //private eBTState CheckObjectType(UnityEngine.Object unit)
    //{
    //    UnitCollider targetCollider = m_owner.GetMainTargetCollider(false);
    //    if ((m_eCompareType == eCompareType.Equal && targetCollider.Owner == unit) || (m_eCompareType == eCompareType.NotEqual && targetCollider.Owner != unit))
    //        return eBTState.Success;

    //    return eBTState.Fail;
    //}

    //private eBTState CheckStateType(string state)
    //{
    //    //if(state == "Stun")
    //    //    return CheckValueType<Unit.eAbnormalCondition>(Unit.eAbnormalCondition.Stun, m_owner.abnormalCondition);

    //    return eBTState.Fail;
    //}

    //private eBTState CheckValueType<T>(T ownerRefValue) where T : IComparable
    //{
    //    switch (m_eCompareType)
    //    {
    //        case eCompareType.Equal:
    //            if (ownerRefValue.CompareTo((T)m_value) == 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.NotEqual:
    //            if (ownerRefValue.CompareTo((T)m_value) != 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.Less:
    //            if (ownerRefValue.CompareTo((T)m_value) < 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.LessEqual:
    //            if (ownerRefValue.CompareTo((T)m_value) <= 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.Greater:
    //            if (ownerRefValue.CompareTo((T)m_value) > 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.GreaterEqual:
    //            if (ownerRefValue.CompareTo((T)m_value) >= 0)
    //                return eBTState.Success;
    //            break;
    //    }

    //    return eBTState.Fail;
    //}

    //private eBTState CheckValueType<T>(T ownerRefValue, T value) where T : IComparable
    //{
    //    switch (m_eCompareType)
    //    {
    //        case eCompareType.Equal:
    //            if (ownerRefValue.CompareTo(value) == 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.NotEqual:
    //            if (ownerRefValue.CompareTo(value) != 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.Less:
    //            if (ownerRefValue.CompareTo(value) < 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.LessEqual:
    //            if (ownerRefValue.CompareTo(value) <= 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.Greater:
    //            if (ownerRefValue.CompareTo(value) > 0)
    //                return eBTState.Success;
    //            break;

    //        case eCompareType.GreaterEqual:
    //            if (ownerRefValue.CompareTo(value) >= 0)
    //                return eBTState.Success;
    //            break;
    //    }

    //    return eBTState.Fail;
    //}
}
