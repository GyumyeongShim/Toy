using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExManager
{
    public void Init()
    {
        GameObject root = GameObject.Find("@SceneEx");
        if (root == null)
        {
            root = new GameObject { name = "@SceneEx" };
            Object.DontDestroyOnLoad(root);
        }
    }
    //public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene type)
    {
        Managers.Clear();

        SceneManager.LoadScene(GetSceneName(type));
    }
    public void LoadScene(string str)
    {
        Managers.Clear();
        SceneManager.LoadScene(str);
    }

    string GetSceneName(Define.Scene type)
    {
        return System.Enum.GetName(typeof(Define.Scene), type);
    }

    public string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void RestartScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Clear()
    {
        //CurrentScene.Clear();
    }
}
