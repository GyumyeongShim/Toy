using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public void Init()
    {
        GameObject root = GameObject.Find("@UI");
        if (root == null)
        {
            root = new GameObject { name = "@UI" };
            Object.DontDestroyOnLoad(root);
        }

        Managers.Resource.Instantiate("UI/UI_ButtonCanvas");
    }

    public void Clear() { }
}
