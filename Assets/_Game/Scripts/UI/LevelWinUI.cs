using System;
using System.Collections;
using System.Collections.Generic;
using Gamingale;
using UnityEngine;
using UnityEngine.UI;

public class LevelWinUI : UIManager
{
    [SerializeField] private GameObject m_LevelWinScreen;
    [SerializeField] Button m_NextButton, m_MenuButton;
    public Action OnClickMenu, OnClickNext;

    private void Start()
    {
        SubscribeLevelWinButtons();
    }

    void SubscribeLevelWinButtons()
    {
        m_NextButton.onClick.AddListener(OnClickNextButton);
        m_MenuButton.onClick.AddListener(OnClickMenuButton);
    }

    private void OnClickMenuButton()
    {
        OnClickMenu?.Invoke();
    }

    private void OnClickNextButton()
    {
        OnClickNext?.Invoke();
    }
}
