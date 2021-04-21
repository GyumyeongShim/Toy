using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public void Init()
    {
        //최초의 데이터를 읽어오고 해당 값으로 pool을 만든다
    }

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // assets/resources/가 기본경로임
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject go)
    {
        if(go == null)
        {
            return;
        }

        Object.Destroy(go);
    }

    public void Clear()
    {

    }
}
