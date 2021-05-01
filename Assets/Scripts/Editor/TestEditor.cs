using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestEditor : EditorWindow
{
    string m_mystr = "Hello World";
    bool m_groupEnabled;
    bool m_myBool = true;
    float m_myFloat = 1.23f;

    [Range(1, 5)]
    public int RangeNum;

    public int TypingNum;

    [TextArea(3, 5)]
    public string textArea;

    [ContextMenuItem("Random", "RandomNumber")]
    [ContextMenuItem("Reset", "ResetNumber")]
    public int number;

    [MenuItem("툴/첫번째 임시 에디터")] //[반각 스페이스 + 수식자 키 + 임의의 문자] 띄어쓰기 + 임의문자(%#F Ctrl+Shift+F)
// % : Ctrl(Windows) 혹은 command(MacOSX) # : Shift & : Alt(Windows) 혹은 option(Mac OS X) _ : 수식자 키 없음
// F1...F12 : Function키 HOME : Home 키 END : End 키 PGUP : PageUp 키  PGDN : PageDown 키 KP0...KP9 : 0부터 9까지의 숫자키
// KP. : . KP+ : + KP- : - KP* : * KP/ : / KP= : =

    static void Init()
    {
        TestEditor window = (TestEditor)EditorWindow.GetWindow(typeof(TestEditor)); //탭윈도우처럼 부착가능

        Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Editor/Example.png");
        //Texture tex = EditorGUIUtility.Load("logo.png") as Texture;

        window.titleContent = new GUIContent("ㅋㅋ",icon);
        window.Show();

        string menuPath = "툴/첫번째 임시 에디터";
        bool tmpchecked = Menu.GetChecked(menuPath);
        Menu.SetChecked(menuPath, !tmpchecked); //에디터가 켜지면 체크표시됨
    }

    private void OnGUI()
    {
        GUILayout.Label("쎼띵쎼띵", EditorStyles.boldLabel); //글자
        m_mystr = EditorGUILayout.TextField("Text Field", m_mystr);

        m_groupEnabled = EditorGUILayout.BeginToggleGroup("활성/비활성", m_groupEnabled);
        m_myBool = EditorGUILayout.Toggle("버튼인 부분?", m_myBool);
        m_myFloat = EditorGUILayout.Slider("슬라이더 -3 ~ 3?", m_myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();


    }

    void RandomNumber()
    {
        number = Random.Range(0, 100);
    }

    void ResetNumber()
    {
        number = 0;
    }

}
