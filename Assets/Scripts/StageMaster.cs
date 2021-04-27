using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageMaster : MonoBehaviour //추후 씬매니저가 이런것을 몇개 가지고 있을것
{
    [Header("Use Common")]
    [SerializeField]
    private string m_nextSceneName; //다음 씬 이름

    [Header("Use MatchCube")]
    [SerializeField]
    private TextMeshProUGUI m_textScore;
    private int m_score;

    [SerializeField]
    private GameObject m_panelResult= null;

    [SerializeField]
    private TextMeshProUGUI m_textResultScore = null;

    [SerializeField]
    private TextMeshProUGUI m_textHighScore = null;

    public bool m_isGameOver { get; private set; }

    [Header("Use Roll A Ball")]
    [SerializeField]
    private GameObject m_panelStageClear; //스테이지 클리어시 나타나는 Panel UI
    private bool m_getAllCoins = false; //모든 코인 획득시 true;

    private int m_maxCoinCount;
    public int MaxCoinCount
    {
        get { return m_maxCoinCount; }
        set { m_maxCoinCount = value; }
    }
    private int m_currentCoinCount;
    public int CurrentCoinCount
    {
        get { return m_currentCoinCount; }
        set { m_currentCoinCount = value; } 
    }

    //public int MaxCoinCount => m_maxCoinCount;
    //public int CurrentCoinCount => m_currentCoinCount;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        if (Managers.Scene.GetActiveSceneName() == "RollABall")
        {
            Managers.Input.m_keyAction -= OnEnterNextScene;
            Managers.Input.m_keyAction += OnEnterNextScene;
            Time.timeScale = 1.0f; //시간 배율 1, 정상 속도로 재생

            //판넬 비활성화해서 가지고 있기
            m_panelStageClear.SetActive(false);

            m_maxCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
            m_currentCoinCount = m_maxCoinCount;
        }
        else if (Managers.Scene.GetActiveSceneName() == "MatchCube")
        {
            Managers.Init();
            m_isGameOver = false;
            m_panelResult.SetActive(false);
            return;
        }
    }

    public void IncreaseScore()
    {
        m_score++;
        m_textScore.text = $"Score : {m_score}";
    }

    public void GameOver()
    {
        m_isGameOver = true;
        m_textScore.enabled = false; //스테이지 점수 출력 UI 비활성화
        m_panelResult.SetActive(true); //결과 화면 UI 활성화

        int highScore = PlayerPrefs.GetInt("HighScore"); //기존 등록된 최고 점수

        //기존 점수가 최고 점수보다 낮을 떄
        if(m_score < highScore)
        {
            m_textHighScore.text = $"High Score : {highScore}";
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", m_score); //현재 점수를 최고 점수로 저장
            m_textHighScore.text = $"High Score : {m_score}";
        }

        m_textResultScore.text = $"Score : {m_score}";
    }

    public void Restart(string sceneName = "")
    {
        if (sceneName == "")
        {
            Managers.Scene.LoadScene(Managers.Scene.GetActiveSceneName());
        }
        else
        {
            Managers.Scene.LoadScene(sceneName);
        }
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
