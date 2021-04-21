using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountViewer : MonoBehaviour
{
    [SerializeField]
    private StageController m_stageController;
    private TextMeshProUGUI m_textCoinCount;

    void Start()
    {
        m_textCoinCount = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        m_textCoinCount.text = m_stageController.ChangeCoin();
    }
}
