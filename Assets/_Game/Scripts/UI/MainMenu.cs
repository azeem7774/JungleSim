using System;
using System.Collections;
using System.Collections.Generic;
using Gamingale;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameScreens m_GameScreen;
    [SerializeField] private Button m_Exit, m_PrivacyPolicy, m_RateUs, m_MoreGames, m_Settings, m_Play;

    public Action<GameScreens> OnScreenSwitch;

    public void Init()
    {
        SubscribeMainMenuScreenButtons();
    }

    private void SubscribeMainMenuScreenButtons()
    {
        m_Exit.onClick.AddListener(OnClickExitButton);
        m_PrivacyPolicy.onClick.AddListener(OnClickPrivacyPolicyButton);
        m_RateUs.onClick.AddListener(OnClickRateUsButton);
        m_MoreGames.onClick.AddListener(OnClickMoreGamesButton);
        m_Settings.onClick.AddListener(OnClickSettingsButton);
        m_Play.onClick.AddListener(OnClickPlayButton);

    }

    private void OnClickExitButton()
    {
        Application.Quit();
    }

    private void OnClickPlayButton()
    {
        OnScreenSwitch?.Invoke(m_GameScreen);
    }

    private void OnClickSettingsButton()
    {
    }

    private void OnClickMoreGamesButton()
    {
    }

    private void OnClickRateUsButton()
    {
    }

    private void OnClickPrivacyPolicyButton()
    {
        Application.OpenURL("https://gamingalestudio.blogspot.com/2023/01/privacy-policy.html");
    }
}
