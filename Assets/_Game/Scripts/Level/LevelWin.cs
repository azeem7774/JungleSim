using System;
using System.Collections;
using System.Collections.Generic;
using Gamingale;
using UnityEngine;
using UnityEngine.UI;

public class LevelWin : MonoBehaviour
{
    public static Action OnLevelWin;
    [SerializeField] Button m_NextButton, m_MenuButton;
    public Action<GameScreens> OnMenuButtonClicked, OnNextButtonClicked;
    [SerializeField] GameScreens m_GameScreens;

    public void Init()
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
        OnMenuButtonClicked?.Invoke(m_GameScreens);
        //m_LevelWinScreen.SetActive(false);
        //m_LoadingScreen.gameObject.SetActive(true);
    }

    private void OnClickNextButton()
    {
        OnNextButtonClicked?.Invoke(m_GameScreens);
        Constants.m_IsCurrenSceneToBeLoaded = true;
    }

    public void ActiveGameObject()
    {
        OnLevelWin?.Invoke();
    }
}
