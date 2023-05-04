using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gamingale
{
    public enum GameScreens
    {
        MainMenu,
        ModScreen,
        LevelScreen,
        LoadingScreen,
        GamPlayMobileControlsScreen,
        PauseScreens,
        LevelWinScreen,
        LevelFailedScreen
    }
    public class UIManager : MonoBehaviour
    {
        public Action OnLoadingComplete;
        [SerializeField] private GameScreens m_GameScreens;
        [SerializeField] private SceneLoader m_SceneLoader;
        [Space(20),Header("Screens")]
        [SerializeField] private MainMenu m_MainMenu;
        [SerializeField] private LevelSelection m_levelSelection;
        [SerializeField] private LevelWin m_levelWin;

        #region Properties
        public LevelSelection m_LevelSelectionScreen => m_levelSelection;

        #endregion

        [SerializeField] private LoadingScreen m_LoadingScreen;

        public LoadingScreen loadingScreen => m_LoadingScreen;

        #region Singloton
        public static UIManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        private void OnEnable()
        {
            LevelWin.OnLevelWin += TurnOffGameplayUI;
            m_LoadingScreen.OnLoadingBarComplete += TurnOnScreenOnSceneChange;
            //loadingScreen.OnLoadingBarComplete += TurnOnScreenOnSceneChange;
            m_MainMenu.OnScreenSwitch += SwitchScreen;
            m_levelSelection.OnExitCliked += SwitchScreen;
            m_levelSelection.OnClickLevelButton += SwitchScreen;
            m_levelWin.OnMenuButtonClicked += SwitchScreen;
            m_levelWin.OnNextButtonClicked += SwitchScreen;
        }


        IEnumerator WaitOnLoading()
        {

            OnLoadingComplete?.Invoke();

            while (!Constants.m_IsSceneLoaded)
                yield return null;
            
            switch (Constants.m_CurrentScene)
            {
                case SceneName.MainMenu:
                    m_MainMenu.gameObject.SetActive(true);
                    break;
                case SceneName.Gamplay:
                    m_MobileControls.SetActive(true);
                    break;
                case SceneName.Gameplay_Nignt:
                    m_MobileControls.SetActive(true);
                    break;
                case SceneName.Gameplay_OpenWorld:
                    m_MobileControls.SetActive(true);
                    break;
            }
            m_LoadingScreen.gameObject.SetActive(false);
        }


        private void TurnOnScreenOnSceneChange()
        {
            StartCoroutine(WaitOnLoading());
        }


        private void TurnOffGameplayUI()
        {
            m_MobileControls.SetActive(false);
            StartCoroutine(WaitForLevelWinEnble());
        }

        IEnumerator WaitForLevelWinEnble()
        {
            yield return new WaitForSeconds(2);

            m_levelWin.gameObject.SetActive(true);
        }

        private void Start()
        {
            m_GameScreens = GameScreens.LoadingScreen;
            m_MainMenu.Init();
            m_levelSelection.Init();
            m_levelWin.Init();
            SubscribePauseMenuButtons();
            SubscribeMobileControlButtons();
            m_LoadingScreen.gameObject.SetActive(true);
        }

        private void SwitchScreen(GameObject screenOn, GameObject screenOff)
        {
            screenOn.SetActive(true);
            screenOff.SetActive(false);
        }

        private void SwitchScreen(GameScreens gs)
        {

            switch (gs)
            {
                case GameScreens.MainMenu:
                    SwitchScreen(m_levelSelection.gameObject, m_MainMenu.gameObject);
                    m_GameScreens = GameScreens.LevelScreen;
                    break;
                case GameScreens.ModScreen:
                    break;
                case GameScreens.LevelScreen:
                    SwitchScreen(loadingScreen.gameObject, m_levelSelection.gameObject);
                    m_GameScreens = GameScreens.LoadingScreen;
                    break;
                case GameScreens.LoadingScreen:
                    TurnOnScreenOnSceneChange();
                    break;
                case GameScreens.GamPlayMobileControlsScreen:
                    SwitchScreen(m_MobileControls, m_levelSelection.gameObject);
                    m_GameScreens = GameScreens.MainMenu;
                    break;
                case GameScreens.LevelWinScreen:
                    SwitchScreen(m_LoadingScreen.gameObject, m_levelWin.gameObject);
                    break;
                case GameScreens.LevelFailedScreen:
                    break;

            }
        }
        //private void LoadNextLevel(GameScreens gs)
        //{
        //    OnLoadNextLevel?.Invoke();
        //    SwitchScreen(gs);
        //}

        private void OnDisable()
        {
            LevelWin.OnLevelWin -= TurnOffGameplayUI;
            m_LoadingScreen.OnLoadingBarComplete -= TurnOnGamplayUI;
            loadingScreen.OnLoadingBarComplete -= TurnOnScreenOnSceneChange;
            m_levelSelection.OnClickLevelButton -= SwitchScreen;
            m_levelWin.OnNextButtonClicked -= SwitchScreen;
        }

        

        

        

        #region GamplayUIControl
        [Header("GamePlayUI"), Space(10)]
        [SerializeField] private GameObject m_MobileControls;
        [SerializeField] private Button m_PauseButton;
        private void TurnOnGamplayUI()
        {
            if (SceneManager.GetActiveScene().buildIndex >= 1)
                m_MobileControls.SetActive(true);
        }

        private void SubscribeMobileControlButtons()
        {
            m_PauseButton.onClick.AddListener(OnClickPause);
        }

        private void OnClickPause()
        {
            Time.timeScale = 0;
            m_PauseScreen.SetActive(true);
            m_MobileControls.SetActive(false);
        }

        #endregion


        #region PauseScreen

        [Header("PauseScreen")]
        [Space(10)]
        [SerializeField] private GameObject m_PauseScreen;
        [SerializeField] private Button m_ResumeButton, m_RestartButton, m_MainMenuButton;

        private void SubscribePauseMenuButtons()
        {
            m_ResumeButton.onClick.AddListener(OnClickResume);
            m_RestartButton.onClick.AddListener(OnClickRestart);
            m_MainMenuButton.onClick.AddListener(OnClickMainMenu);
        }

        private void OnClickMainMenu()
        {
            m_PauseScreen.SetActive(false);
            m_LoadingScreen.gameObject.SetActive(true);
            m_MobileControls.SetActive(false);
            Time.timeScale = 1;
        }

        private void OnClickRestart()
        {
            m_PauseScreen.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            m_MobileControls.SetActive(true);
            Time.timeScale = 1;
        }

        private void OnClickResume()
        {
            m_MobileControls.SetActive(true);
            Time.timeScale = 1;
            m_PauseScreen.SetActive(false);

        }

        #endregion

    }
}
