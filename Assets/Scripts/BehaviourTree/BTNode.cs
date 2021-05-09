using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode : MonoBehaviour
{
    public enum eBTState
    {
        Success,
        Fail,
        Running
    }

    protected string m_name = null;
    protected BaseController m_owner = null;
    protected List<BTNode> m_listChild = new List<BTNode>();

    public eBTState m_BTState { get; protected set; }

    public BTNode(string name, BaseController owner) //생성자
    {
        m_name = name;
        m_owner = owner;
    }

    public abstract IEnumerator Invoke(BTNode root);

    public void AddChild(BTNode node) => m_listChild.Add(node);
}
