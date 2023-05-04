using System;
using Gamingale;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] GameScreens m_GameScreens;
    [SerializeField] private Button[] m_LevelSelectionButtons;
    [SerializeField] private Button m_LevelScreenExitButton;
    public Action<GameScreens> OnExitCliked, OnClickLevelButton; 
    private int m_UnlocklLevel;

    private void OnEnable()
    {
        m_UnlocklLevel = PreferenceManager.UnlockLevel;
        Helper.ToggleInteractableButton(m_LevelSelectionButtons, m_LevelSelectionButtons.Length, false);
        Helper.ToggleInteractableButton(m_LevelSelectionButtons, m_UnlocklLevel, true);
    }

    public void Init()
    {
        SubscribeLevelScreenButton();
    }

    private void OnCLickLevelSelect(int levelIndex)
    {
        PreferenceManager.LevelIndex = levelIndex;
        OnClickLevelButton?.Invoke(m_GameScreens);
        MaxAdManager.Instance.ShowMainMenuInterstitial();
    }

    private void SubscribeLevelSelectButton(Button[] buttons)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int copy = i;
            buttons[i].onClick.AddListener(() => { OnCLickLevelSelect(copy); }) ;
        }
    }

    private void SubscribeLevelScreenButton()
    {
        SubscribeLevelSelectButton(m_LevelSelectionButtons);
        m_LevelScreenExitButton.onClick.AddListener(OnClickLevelScreenExit);
    }

    private void OnClickLevelScreenExit()
    {
        OnExitCliked?.Invoke(m_GameScreens);
    }
    private void ToggleLevels(Button[] buttons, int maxRange, bool enable)
    {
        for (int i = 1; i < maxRange; i++) buttons[i].interactable = enable;
    }

}
