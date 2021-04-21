using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers m_instance;
    static Managers Instance
    {
        get { Init(); return m_instance; }
    }

    #region Manager
    DataManager m_data = new DataManager();
    EffectManager m_effect = new EffectManager();
    InputManager m_input = new InputManager();
    PoolManager m_pool = new PoolManager();
    ResourceManager m_resource = new ResourceManager();
    SceneExManager m_scene = new SceneExManager();
    StageManager m_stage = new StageManager();
    SoundManager m_sound = new SoundManager();
    UIManager m_ui = new UIManager();

    public static DataManager Data { get { return Instance.m_data; } }
    public static EffectManager Effect { get { return Instance.m_effect; } }
    public static InputManager Input { get { return Instance.m_input; } }
    public static PoolManager Pool { get { return Instance.m_pool; } }
    public static ResourceManager Resource { get { return Instance.m_resource; } }
    public static SceneExManager Scene { get { return Instance.m_scene; } }
    public static StageManager Stage { get { return Instance.m_stage; } }
    public static SoundManager Sound { get { return Instance.m_sound; } }
    public static UIManager UI { get { return Instance.m_ui; } }
    #endregion

    void Start()
    {
        Init();
    }

    void Update()
    {
        m_input.OnUpdate();
    }

    public static void Init()
    {
        if(m_instance == null) //Managers가 없다면?
        {
            GameObject go = GameObject.Find("@Managers"); //하이어라키에 등록된 모든 오브젝트 중에 있는지?
            if (go == null)
            {
                go = new GameObject { name = "@Managers" }; //없으면 만들어줍니다
                go.AddComponent<Managers>(); //빈게임오브젝트인 "@Managers"에 Managers 스크립트를 추가해줍니다.
            }

            DontDestroyOnLoad(go);
            m_instance = go.GetComponent<Managers>();

            //매니저들 초기화
            //데이터를 읽어서 테이블을 저장하고
            //저장된 테이블을 바탕으로 리소스를 만든다
            //만들어진 리소스에 pool 컴포넌트를 추가하거나 안하거나
            //만들어진 오브젝트를 스테이지에 넣어서 관리한다
            //배치된 오브젝트가 담긴 스테이지를 씬에 관리한다
            //data->resource->effect,pool,ui->stage->scene
            m_instance.m_input.Init();
            m_instance.m_data.Init();
            m_instance.m_resource.Init();
            m_instance.m_pool.Init();
            m_instance.m_effect.Init();
            m_instance.m_ui.Init();
            m_instance.m_sound.Init();
            m_instance.m_stage.Init();
            m_instance.m_scene.Init();
        }

    }

    public static void Clear()
    {
        //모든것을 초기화
        Input.Clear();
        //Data.Clear();
        //Resource.Clear();
        //Pool.Clear();
        //Effect.Clear();
        //UI.Clear();
        //Sound.Clear();
        //Stage.Clear();
        //Scene.Clear();
    }
}
