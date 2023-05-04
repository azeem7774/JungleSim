using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenUI : MonoBehaviour
{
    [SerializeField] private Button m_ResumeButton, m_RestartButton, m_MainMenuButton;
    public Action OnClickMainMenu, OnClickRestart, OnClickResume;
    public void Init()
    {
        SubscribePauseMenuButtons();
    }

    private void SubscribePauseMenuButtons()
    {
        m_ResumeButton.onClick.AddListener(OnClickResumeButton);
        m_RestartButton.onClick.AddListener(OnClickRestartButton);
        m_MainMenuButton.onClick.AddListener(OnClickMainMenuButton);
    }

    private void OnClickMainMenuButton()
    {
        OnClickMainMenu?.Invoke();
        Time.timeScale = 1;
    }

    private void OnClickRestartButton()
    {
        OnClickRestart?.Invoke();
        Time.timeScale = 1;
    }

    private void OnClickResumeButton()
    {
        OnClickResume?.Invoke();
        Time.timeScale = 1;

    }
}
