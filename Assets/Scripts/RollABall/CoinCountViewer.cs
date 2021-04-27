using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountViewer : MonoBehaviour
{
    [SerializeField]
    private StageMaster m_StageMaster;
    private TextMeshProUGUI m_textCoinCount;

    void Start()
    {
        m_textCoinCount = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        m_textCoinCount.text = m_StageMaster.ChangeCoin();
    }
}
