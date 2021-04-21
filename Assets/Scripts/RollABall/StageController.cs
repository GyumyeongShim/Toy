using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour //추후 씬매니저가 이런것을 몇개 가지고 있을것
{
    [SerializeField]
    private string m_nextSceneName; //다음 씬 이름

    [SerializeField]
    private GameObject m_panelStageClear; //스테이지 클리어시 나타나는 Panel UI

    private int m_maxCoinCount;
    private int m_currentCoinCount;

    private bool m_getAllCoins = false; //모든 코인 획득시 true;

    public int MaxCoinCount => m_maxCoinCount;
    public int CurrentCoinCount => m_currentCoinCount;

    void Start()
    {
        Managers.Input.m_keyAction -= OnEnterNextScene;
        Managers.Input.m_keyAction += OnEnterNextScene;
        Time.timeScale = 1.0f; //시간 배율 1, 정상 속도로 재생

        //판넬 비활성화해서 가지고 있기
        m_panelStageClear.SetActive(false);

        m_maxCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        m_currentCoinCount = m_maxCoinCount;
    }

    public void GetCoin()
    {
        m_currentCoinCount--;
        if (m_currentCoinCount == 0)
        {
            //스테이지 클리어
            m_getAllCoins = true;
            Time.timeScale = 0.0f;
            m_panelStageClear.SetActive(true);
        }
    }

    public string ChangeCoin()
    {
        string coin = "Coins : " + m_currentCoinCount + "/" + m_maxCoinCount;

        return coin;
    }

    void OnEnterNextScene()
    {
        if (m_getAllCoins == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Managers.Scene.LoadScene(m_nextSceneName);
            }
        }
    }
}
