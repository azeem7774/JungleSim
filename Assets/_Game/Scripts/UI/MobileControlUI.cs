using System.Collections;
using System.Collections.Generic;
using Gamingale;
using UnityEngine;
using UnityEngine.UI;

public class MobileControlUI : UIManager
{
    [SerializeField] private Button m_PauseButton;

    private void Start()
    {
        SubscribeMobileControlButtons();
    }

    private void SubscribeMobileControlButtons()
    {
        m_PauseButton.onClick.AddListener(OnClickPause);
    }

    private void OnClickPause()
    {
        Time.timeScale = 0;
    }
}
