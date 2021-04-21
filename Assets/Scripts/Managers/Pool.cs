using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    //풀링할 오브젝트는 이 컴포넌트를 갖고 있어야함!
    //프리펩부터 가지고 있거나 혹은 추가할 경우 해당 컴포넌트를 추가하는 방향
    public GameObject Original { get; set; }

    public bool isActive()
    {
        return Original.activeSelf;
    }

    public void SetActive(bool isAct)
    {
        Original.SetActive(isAct);
    }
}
